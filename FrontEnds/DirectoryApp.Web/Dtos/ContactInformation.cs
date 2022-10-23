using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Dtos
{

    public class ContactInformation
    {
       
        
        public int ContactInformationId { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }
        public bool isDeleted { get; set; }
        public string PersonId { get; set; }
    }
}
