using CurriculumVitae.Shared.DtoModels;
using FluentValidation;

namespace CurriculumVitae.Validation.Validators;

public class ContactInformationValidator : AbstractValidator<ContactInformation>
{
    public ContactInformationValidator()
    {
        RuleFor(c => c.Email).EmailAddress();
    }
}