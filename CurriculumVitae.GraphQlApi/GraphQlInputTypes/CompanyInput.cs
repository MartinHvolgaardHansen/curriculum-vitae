using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlInputTypes;

public class CompanyInput : InputObjectGraphType<Company>
{
    public CompanyInput()
    {
        Name = nameof(CompanyInput);
        Field(c => c.Name).Description("The name of the company");
        Field(c => c.ContactInformation.Email).Description("The email used to reach a point of contact in the company");
        Field<ListGraphType<PhoneInput>>("phones");
        Field(c => c.ContactInformation.AddressLineOne).Description("Company address line 1");
        Field(c => c.ContactInformation.AddressLineTwo, nullable: true).Description("Company address line 2 (optional)");
        Field(c => c.ContactInformation.City).Description("The name of the city in which the company is based");
        Field(c => c.ContactInformation.Region, nullable: true).Description("The name of the region in which the company is based");
        Field(c => c.ContactInformation.Country).Description("The name of the country in which the company is based");
    }
}
