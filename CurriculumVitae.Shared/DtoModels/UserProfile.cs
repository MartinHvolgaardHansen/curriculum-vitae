namespace CurriculumVitae.Shared.DtoModels;

public class UserProfile
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public string Discription { get; set; }
    public IEnumerable<Employment> Employments { get; set; }
    public IEnumerable<Education> Educations { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
}