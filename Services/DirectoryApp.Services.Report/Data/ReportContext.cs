using Microsoft.EntityFrameworkCore;
using DirectoryApp.Services.Report.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Report.Data
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options)
        : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<ReportResult> Report { get; set; }
    }
}
