using System;
using CurriculumVitae.Domain.Services;
using CurriculumVitae.GraphQlApi.GraphQlInputTypes;
using CurriculumVitae.GraphQlApi.GraphQlQueryTypes;
using CurriculumVitae.Shared.DtoModels;
using GraphQL;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlSchema;

public class Mutation : ObjectGraphType
{
    private readonly ICompanyService _companyService;

    public Mutation(ICompanyService companyService)
    {
        _companyService = companyService;

        Setup();
    }

    private void Setup()
    {
        Name = nameof(Mutation);

        Field<CompanyType>(
            "createCompany",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CompanyInput>> { Name = nameof(Company) }
            ),
            resolve: context =>
            {
                var company = context.GetArgument<Company>("company");
                return _companyService.Add(company);
            }
            );
    }
}