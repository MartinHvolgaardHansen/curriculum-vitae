using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlInputTypes;

public class CompanyInput : InputObjectGraphType<Company>
{
    public CompanyInput()
    {
        Name = nameof(CompanyInput);
        Field(c => c.Name);
        Field(c => c.ContactInformation.Email);
        Field<ListGraphType<PhoneInput>>("phones");
        Field(c => c.ContactInformation.AddressLineOne);
        Field(c => c.ContactInformation.AddressLineTwo, nullable: true);
        Field(c => c.ContactInformation.City);
        Field(c => c.ContactInformation.Region, nullable: true);
        Field(c => c.ContactInformation.Country);
    }
}
