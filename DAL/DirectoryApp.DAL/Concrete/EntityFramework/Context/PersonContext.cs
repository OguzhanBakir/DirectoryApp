using DirectoryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DirectoryApp.DAL.Concrete.EntityFramework.Context
{
    public class PersonContext : DbContext
    {
       
        public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("User ID=postgres;Password=q1w2e3r4.OB;Host=localhost;Port=5432;Database=DemoDirectoryApp;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContactInformation>()
                .Property(p => p.ContactInformationId)
                .ValueGeneratedOnAdd();

           


        }


    }
}
