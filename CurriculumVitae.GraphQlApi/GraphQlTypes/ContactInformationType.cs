using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlTypes;

public class ContactInformationType : ObjectGraphType<ContactInformation>
{
    public ContactInformationType()
    {
        Name = nameof(ContactInformation);
        Field(c => c.Id);
        Field(c => c.Email);
        Field(c => c.Phones);
        Field(c => c.AddressLineOne);
        Field(c => c.AddressLineTwo);
        Field(c => c.City);
        Field(c => c.Region);
        Field(c => c.Country);
    }
}