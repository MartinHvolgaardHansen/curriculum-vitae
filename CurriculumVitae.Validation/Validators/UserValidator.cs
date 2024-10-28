using CurriculumVitae.Shared.DtoModels;
using FluentValidation;

namespace CurriculumVitae.Validation.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(IValidator<ContactInformation> contactInformationValidator)
    {
        RuleFor(u => u.FirstName).NotNull().NotEmpty();
        RuleFor(u => u.LastName).NotNull().NotEmpty();
        RuleFor(u => u.ContactInformation).SetValidator(contactInformationValidator);
    }
}