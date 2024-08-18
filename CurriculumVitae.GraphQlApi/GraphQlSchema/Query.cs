using CurriculumVitae.Domain.Services;
using CurriculumVitae.GraphQlTypes;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlSchema;

public class Query : ObjectGraphType<object>
{
    private readonly ICompanyService _service;

    public Query(ICompanyService service)
    {
        _service = service;
        Setup();
    }

    private void Setup()
    {
        Name = nameof(Query);
        FieldAsync<ListGraphType<CompanyType>>("companies", resolve: async context => await _service.Get());
    }
}