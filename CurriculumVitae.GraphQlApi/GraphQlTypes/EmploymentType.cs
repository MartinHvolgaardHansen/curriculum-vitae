using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class EmploymentType : ObjectGraphType<Employment>
{
    public EmploymentType()
    {
        Name = nameof(Employment);
        Field(e => e.Id);
        Field(e => e.Company);
        Field(e => e.From);
        Field(e => e.To);
    }
}
