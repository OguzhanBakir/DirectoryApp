using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DirectoryApp.Core.Entities
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public bool isDeleted { get; set; }
        public List<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
    }
}
