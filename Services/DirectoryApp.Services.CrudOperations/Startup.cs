using DirectoryApp.BLL.Abstract;
using DirectoryApp.BLL.Concrete;
using DirectoryApp.BLL.ValidationRules.FluentValidation;
using DirectoryApp.Core.Entities;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.DAL.Concrete.Managers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations
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

            services.AddHttpContextAccessor();







            services.AddControllers().AddFluentValidation();
           

            services.AddSwaggerGen(c => {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DirectoryApp.Services.CrudOperations", Version = "v1" });
            //});

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<PersonContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            services.AddTransient<IPersonService,PersonManager>();
            services.AddTransient<IPersonDAL, EfPersonDAL>();

            services.AddTransient<IContactInformationService, ContactInformationManager>();
            services.AddTransient<IContactInformationDAL, EfContactInformationDAL>();

            services.AddTransient<IValidator<Person>, PersonValidator>();
            services.AddTransient<IValidator<ContactInformation>, ContactInformationValidator>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DirectoryApp.Services.CrudOperations v1"));
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
