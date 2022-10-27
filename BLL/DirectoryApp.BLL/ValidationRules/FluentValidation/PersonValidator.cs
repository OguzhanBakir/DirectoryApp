using DirectoryApp.Core.Entities;
using FluentValidation;

namespace DirectoryApp.BLL.ValidationRules.FluentValidation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            //RuleFor(x => x.PersonId).NotNull().NotEmpty().WithMessage("Person Id cannot be empty");


            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("The first name cannot be empty");
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).WithMessage("The first name must be at least 2 characters");
            RuleFor(x => x.FirstName).NotNull().Matches(@"^[a-zA-Z]+$").WithMessage("The first name only accept letters");


            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("The last name cannot be empty");
            RuleFor(x => x.LastName).NotNull().MinimumLength(2).WithMessage("The last name must be at least 2 characters");
            RuleFor(x => x.LastName).NotNull().Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖö]*$").WithMessage("The last name only accept letters");


            RuleFor(x => x.Company).NotEmpty().WithMessage("The company name cannot be empty");
            RuleFor(x => x.Company).MinimumLength(5).WithMessage("The company name be at least 5 characters");




        }
    }

}
