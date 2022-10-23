using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public bool isDeleted { get; set; }

        public virtual List<ContactInformation> ContactInformation { get; set; } = new List<ContactInformation>();
    }
}
