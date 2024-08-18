using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class PhoneType : ObjectGraphType<Phone>
{
    public PhoneType()
    {
        Name = nameof(Phone);
        Field(p => p.Id);
        Field(p => p.PhoneNumber);
        Field(p => p.CountryCode);
    }
}