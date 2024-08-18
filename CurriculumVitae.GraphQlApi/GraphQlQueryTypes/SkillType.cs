using CurriculumVitae.Shared.DtoModels;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlQueryTypes;

public class SkillType : ObjectGraphType<Skill>
{
    public SkillType()
    {
        Name = nameof(Skill);
        Field(s => s.Id);
        Field(s => s.Name);
        Field(s => s.AcknowledgingUsers);
    }
}