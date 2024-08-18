using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlInputTypes;

public class PhoneInput : InputObjectGraphType<Phone>
{
    public PhoneInput()
    {
        Name = nameof(PhoneInput);
        Field(c => c.PhoneNumber);
        Field(c => c.CountryCode);
    }
}