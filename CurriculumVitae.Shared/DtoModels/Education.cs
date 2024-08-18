namespace CurriculumVitae.Shared.DtoModels;

public class Education
{
    public Guid Id { get; set; }
    public School School { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
}