using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlInputTypes;

public class ContactInformationInput : InputObjectGraphType<ContactInformation>
{
    public ContactInformationInput()
    {
        Name = nameof(ContactInformationInput);
        Field(c => c.AddressLineOne);
        Field(c => c.AddressLineTwo);
        Field(c => c.City);
        Field(c => c.Region);
        Field(c => c.Country);
        Field(c => c.Email);
        Field<ListGraphType<PhoneInput>>("phones");
    }
}