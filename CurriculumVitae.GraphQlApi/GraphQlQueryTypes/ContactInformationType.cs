using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

public class ContactInformationType : ObjectGraphType<ContactInformation>
{
    public ContactInformationType()
    {
        Name = nameof(ContactInformation);
        Field(c => c.Id);
        Field(c => c.Email);
        Field<ListGraphType<PhoneType>>("phones", resolve: context => context.Source.Phones);
        Field(c => c.AddressLineOne);
        Field(c => c.AddressLineTwo, nullable: true);
        Field(c => c.City);
        Field(c => c.Region, nullable: true);
        Field(c => c.Country);
    }
}