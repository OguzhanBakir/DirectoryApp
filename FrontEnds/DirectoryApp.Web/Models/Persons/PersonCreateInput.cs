using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Models.Persons
{
    public class PersonCreateInput
    {
        [Required(ErrorMessage = "The first name cannot be empty")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The first name must be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The first name only accept letters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name cannot be empty")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The last name be at least 2 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The last name only accept letters")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The company name cannot be empty")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "The company name be at least 5 characters")]
        [Display(Name = "Company Name")]
        public string Company { get; set; }

    }
}
