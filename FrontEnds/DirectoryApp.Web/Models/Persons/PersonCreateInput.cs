using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Models.Persons
{
    public class PersonCreateInput
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Company Name")]
        public string Company { get; set; }

    }
}
