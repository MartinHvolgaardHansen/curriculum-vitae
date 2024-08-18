using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class EducationType : ObjectGraphType<Education>
{
    public EducationType()
    {
        Name = nameof(Education);
        Field(e => e.Id);
        Field(e => e.School);
        Field(e => e.From);
        Field(e => e.To);
    }
}