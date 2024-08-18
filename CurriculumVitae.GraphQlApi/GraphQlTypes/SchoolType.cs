using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class SchoolType : ObjectGraphType<School>
{
    public SchoolType()
    {
        Name = nameof(School);
        Field(s => s.Id);
        Field(s => s.Name);
        Field(s => s.ContactInformation);
    }

}