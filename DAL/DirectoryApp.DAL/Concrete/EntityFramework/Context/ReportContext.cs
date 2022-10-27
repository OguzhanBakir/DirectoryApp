using DirectoryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DirectoryApp.DAL.Concrete.EntityFramework.Context
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
        : base(options)
        {

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("User ID=postgres;Password=q1w2e3r4.OB;Host=localhost;Port=5432;Database=DemoDirectoryAppReport;Pooling=true;");
        }


        public DbSet<ReportResult> Report { get; set; }
    }
}
