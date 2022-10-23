using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Dto
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public bool isDeleted { get; set; }
        public List<ContactInformation> ContactInformation { get; set; } = new List<ContactInformation>();
    }
}
