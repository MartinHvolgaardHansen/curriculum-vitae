using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Name = nameof(User);
        Field(u => u.Id);
        Field(u => u.FirstName);
        Field(u => u.LastName);
        Field(u => u.ContactInformation);
    }
}