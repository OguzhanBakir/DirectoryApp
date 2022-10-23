using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Models
{
 
    public class ContactInformation : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ContactInformationId { get; set; }
        public string ContactType { get; set; }
        public string ContactValue { get; set; }

        public bool isDeleted { get; set; }
        public Guid PersonId { get; set; }

        //public virtual Person Person { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string regularExpression = "";
            Regex regex;
            switch (ContactType)
            {
                case "EPosta":
                    regularExpression = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

                    regex = new Regex(regularExpression);
                    if (!regex.IsMatch(ContactValue))
                    {
                        yield return new ValidationResult("The e-mail address is invalid");

                    }
                    break;

                case "Telefon":
                    regularExpression = @"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$";
                    regex = new Regex(regularExpression);
                    if (!regex.IsMatch(ContactValue))
                    {
                        yield return new ValidationResult("The phone number is invalid. It starts with 0");
                    }

                    break;

            }


        }
    }
}
