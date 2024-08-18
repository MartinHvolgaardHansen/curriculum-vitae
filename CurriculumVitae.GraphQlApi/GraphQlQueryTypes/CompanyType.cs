using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

public class CompanyType : ObjectGraphType<Company>
{
    public CompanyType()
    {
        Name = nameof(Company);
        Field(c => c.Id);
        Field(c => c.Name);
        Field<ContactInformationType>(
            "contactInformation",
            resolve: context => context.Source.ContactInformation
        );
    }    
}