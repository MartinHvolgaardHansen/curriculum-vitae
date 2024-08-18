namespace CurriculumVitae.Shared.DtoModels;

public class Skill
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<User> AcknowledgingUsers { get; set; }
}