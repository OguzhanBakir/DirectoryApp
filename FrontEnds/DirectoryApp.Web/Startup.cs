using DirectoryApp.BLL.Abstract;
using DirectoryApp.BLL.Concrete;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DirectoryApp.Web
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


           

            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

           

            services.AddControllersWithViews();


            //services.AddTransient<IPersonService, PersonManager>();
            //services.AddTransient<IPersonDAL, EfPersonDAL>();
            //services.AddTransient<IReportResultService, ReportResultManager>();
            //services.AddTransient<IReportResultDAL, EfReportResultDAL>();
            //services.AddTransient<IContactInformationService, ContactInformationManager>();
            //services.AddTransient<IContactInformationDAL, EfContactInformationDAL>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
