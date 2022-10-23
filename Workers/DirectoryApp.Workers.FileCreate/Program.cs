using DirectoryApp.Workers.FileCreate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Workers.FileCreate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration Configuration = hostContext.Configuration;

                    
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                    services.AddSingleton<RabbitMQClientService>();
                    services.AddSingleton(sp => new ConnectionFactory() { HostName = Configuration.GetConnectionString("RabbitMQ"), DispatchConsumersAsync = true });
                });
    }
}
