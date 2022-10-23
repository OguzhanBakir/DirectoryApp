using ClosedXML.Excel;
using DirectoryApp.Services.Report.Shared;
using DirectoryApp.Shared.Dtos;
using DirectoryApp.Workers.FileCreate.Models;
using DirectoryApp.Workers.FileCreate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DirectoryApp.Workers.FileCreate.Definitions;
using System.Net.Http.Json;

namespace DirectoryApp.Workers.FileCreate
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RabbitMQClientService _rabbitMQClientService;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        DataTable tablePersonLocation,tablePhoneNumber;




        public Worker(ILogger<Worker> logger, RabbitMQClientService rabbitMQClientService, IServiceProvider serviceProvider, IConfiguration configuration, HttpClient client,ConnectionFactory connectionFactory)
        {
            _logger = logger;
            _rabbitMQClientService = rabbitMQClientService;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _client = client;
            _connectionFactory = connectionFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {

            _channel = _rabbitMQClientService.Connect();
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {


            var consumer = new AsyncEventingBasicConsumer(_channel);



            try
            {
                _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);
                
            }

            catch (RabbitMQ.Client.Exceptions.OperationInterruptedException ex)
            {
                _connection = _connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare("ExcelDirectExchange", type: "direct", true, false);
                _channel.QueueDeclare(RabbitMQClientService.QueueName, true, false, false, null);
                _channel.QueueBind(exchange: "ExcelDirectExchange", queue: RabbitMQClientService.QueueName, routingKey: "person-excel-route-file");
                _channel.BasicConsume(RabbitMQClientService.QueueName, false, consumer);
            }


            finally
            {
                consumer.Received += Consumer_Received;
            }
           


            return Task.CompletedTask;
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            await Task.Delay(1000);



            var response = await _client.GetAsync($"{StaticDefinition.apiBaseUrl}/api/ContactInformation");
             
            if (response.IsSuccessStatusCode)
            {



                var responseContactList = await response.Content.ReadFromJsonAsync<Response<List<ContactInformation>>>();

                List<ContactInformation> lstInformation = responseContactList.Data;


                var result = lstInformation.Where(x=>x.ContactType=="Konum").GroupBy(x => new { x.ContactValue})
                   .Select(g => new { g.Key.ContactValue, PersonCount = g.Count() }).ToList();



                tablePersonLocation = new DataTable { TableName = "PersonLocationCount" };



                tablePersonLocation.Columns.Add("Location", typeof(string));
                tablePersonLocation.Columns.Add("PersonCount", typeof(string));

                result.ForEach(x =>
                {
                    tablePersonLocation.Rows.Add(x.ContactValue, x.PersonCount);

                });





                var createExcelMessage = JsonSerializer.Deserialize<CreateExcelMessage>(Encoding.UTF8.GetString(@event.Body.ToArray()));


                using var ms = new MemoryStream();
                var wb = new XLWorkbook();
                var ds = new DataSet();

                ds.Tables.Add(tablePersonLocation);

                wb.Worksheets.Add(ds);
                wb.SaveAs(ms);

                MultipartFormDataContent multipartFormDataContent = new();

                string generatedFileName = Guid.NewGuid().ToString() + ".xlsx";

                multipartFormDataContent.Add(new ByteArrayContent(ms.ToArray()), "file", generatedFileName);

                var baseUrl = $"{StaticDefinition.apiWebBaseUrl}/FileUpload";

                using (var httpClient = new HttpClient())
                {

                    var responseExcelPost = await httpClient.PostAsync($"{baseUrl}?reportResultId={createExcelMessage.ReportResultId}&fileName={generatedFileName}", multipartFormDataContent);

                    if (responseExcelPost.IsSuccessStatusCode)
                    {

                        var baseUpdateUrl = $"{StaticDefinition.reportApiBaseUrl}/FileStatusUpdate";

                        var responseUpdateUrl = await httpClient.PostAsync($"{baseUpdateUrl}?reportResultId={createExcelMessage.ReportResultId}&fileName={generatedFileName}", null);

                        if (responseUpdateUrl.IsSuccessStatusCode)
                        {


                            _logger.LogInformation($"File Id : {createExcelMessage.ReportResultId} was created");
                            _channel.BasicAck(@event.DeliveryTag, false);
                        }
                    }

                    else
                    {
                        _logger.LogInformation($"File Id : {createExcelMessage.ReportResultId} - File crete error");

                    }
                }
            }

        }

    }
}
