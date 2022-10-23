using DirectoryApp.Services.CrudOperations.Models;
using FluentValidation;

namespace DirectoryApp.Services.CrudOperations.Validators
{
    public class ContactInformationValidator : AbstractValidator<ContactInformation>
    {
        public ContactInformationValidator()
        {

            RuleFor(x => x.PersonId).NotNull().NotEmpty().WithMessage("Person Id cannot be empty");

            RuleFor(x => x.ContactType).NotNull().NotEmpty().WithMessage("The contact type cannot be empty");

            RuleFor(x => x.ContactValue).NotNull().NotEmpty().WithMessage("The contact value cannot be empty");
            RuleFor(x => x.ContactValue).MinimumLength(3).WithMessage("The contact value must be at least 3 characters");


            

        }
    }
}
