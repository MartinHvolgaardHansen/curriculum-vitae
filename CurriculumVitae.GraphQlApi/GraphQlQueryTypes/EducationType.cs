using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

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