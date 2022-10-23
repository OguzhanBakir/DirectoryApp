using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DirectoryApp.Web.Models.ContactInformations
{
    public class ContactInformationAddViewModel : IValidatableObject
    {
        public ContactInformationAddViewModel()
        {
            InformationTypes = new List<SelectListItem>()
            {
                new SelectListItem{Text="Mail",Value="Mail"},
                new SelectListItem{Text="Phone",Value="Phone"},
                new SelectListItem{Text="Location",Value="Location"}
            };

        }
        public string ContactType { get; set; }
        public string PersonId { get; set; }

        [Required(ErrorMessage = "The contact value cannot be empty")]

        public string ContactValue { get; set; }
        public string SelectedCity { get; set; }
        public int InformationTypeId { get; set; }

        public List<SelectListItem> InformationTypes { get; set; }
        public List<SelectListItem> Cities { get; set; }
    




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
                        yield return new ValidationResult("The phone number is invalid. It stars with 0");
                    }

                    break;

            }


        }


    }
}
