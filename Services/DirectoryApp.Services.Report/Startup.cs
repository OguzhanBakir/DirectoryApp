using DirectoryApp.BLL.Abstract;
using DirectoryApp.BLL.Concrete;
using DirectoryApp.Core.Utilities.RabbitMQ;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.DAL.Concrete.Managers;
using DirectoryApp.Services.Report.Injector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Report
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(sp => new ConnectionFactory() { HostName=Configuration.GetConnectionString("RabbitMQ"), DispatchConsumersAsync = true });

            services.AddSingleton<RabbitMQPublisher>();
            services.AddSingleton<RabbitMQClientService>();
            services.AddHttpContextAccessor();

            //services.AddTransient<IPersonService, PersonManager>();
            //services.AddTransient<IPersonDAL, EfPersonDAL>();
            //services.AddTransient<IReportResultService, ReportResultManager>();
            //services.AddTransient<IReportResultDAL, EfReportResultDAL>();
            //services.AddTransient<IContactInformationService, ContactInformationManager>();
            //services.AddTransient<IContactInformationDAL, EfContactInformationDAL>();


            services.AddControllers();


            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<ReportContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            //services.Register();
            //services.AddTransient<IPersonService, PersonManager>();
            //services.AddTransient<IPersonDAL, EfPersonDAL>();
            services.AddTransient<IReportResultService, ReportResultManager>();
            services.AddTransient<IReportResultDAL, EfReportResultDAL>();
            //services.AddTransient<IContactInformationService, ContactInformationManager>();
            //services.AddTransient<IContactInformationDAL, EfContactInformationDAL>();


            services.AddSwaggerGen(c => {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);
            });







        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryApp.Services.Report v1"));
            }

      

            app.UseRouting();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
