using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

public class UserProfileType : ObjectGraphType<UserProfile>
{
    public UserProfileType()
    {
        Name = nameof(UserProfile);
        Field(u => u.Id);
        Field(u => u.User);
        Field(u => u.Discription);
        Field(u => u.Employments);
        Field(u => u.Educations);
        Field(u => u.Skills);
    }
}