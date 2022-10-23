using DirectoryApp.Web.Models.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Models.Persons
{
    public class PersonViewModel
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Boolean isDeleted { get; set; }
        public List<ContactInformationViewModel> ContactInformation { get; set; }
    }
}
