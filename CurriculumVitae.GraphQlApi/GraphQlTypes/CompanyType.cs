using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class CompanyType : ObjectGraphType<Company>
{
    public CompanyType()
    {
        Name = nameof(Company);
        Field(c => c.Id);
        Field(c => c.Name);
        // Field(c => c.ContactInformation);
    }    
}