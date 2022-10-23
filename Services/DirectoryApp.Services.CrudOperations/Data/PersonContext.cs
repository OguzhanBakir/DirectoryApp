using DirectoryApp.Services.CrudOperations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Data
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContactInformation>()
                .Property(p => p.ContactInformationId)
                .ValueGeneratedOnAdd();



        }


    }
}
