using CurriculumVitae.Domain.Services;
using CurriculumVitae.GraphQlApi.GraphQlQueryTypes;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlSchema;

public class Query : ObjectGraphType<object>
{
    private readonly ICompanyService _companyService;

    public Query(ICompanyService companyService)
    {
        _companyService = companyService;

        Name = nameof(Query);
        FieldAsync<ListGraphType<CompanyType>>("companies", resolve: async context => await _companyService.Get());
    }
}