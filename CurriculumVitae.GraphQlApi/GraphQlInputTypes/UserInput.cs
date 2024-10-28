using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlInputTypes;

public class UserInput : InputObjectGraphType<User>
{
    public UserInput()
    {
        Name = nameof(UserInput);
        Field(c => c.FirstName);
        Field(c => c.LastName);
        Field<ObjectGraphType<ContactInformationInput>>("contactInformation");
    }
}