using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Models.ContactInformations
{
    public class ContactInformationViewModel
    {

        public int ContactInformationId { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }
        public bool isDeleted { get; set; }
        public Guid PersonId { get; set; }

    }
}
