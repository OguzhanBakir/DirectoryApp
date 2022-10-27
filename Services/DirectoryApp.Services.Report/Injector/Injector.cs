using DirectoryApp.BLL.Abstract;
using DirectoryApp.BLL.Concrete;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryApp.Services.Report.Injector
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {

            services.AddTransient<IPersonService, PersonManager>();
            services.AddTransient<IPersonDAL, EfPersonDAL>();
            services.AddTransient<IReportResultService, ReportResultManager>();
            services.AddTransient<IReportResultDAL, EfReportResultDAL>();
            services.AddTransient<IContactInformationService, ContactInformationManager>();
            services.AddTransient<IContactInformationDAL, EfContactInformationDAL>();
        }
    }
}
