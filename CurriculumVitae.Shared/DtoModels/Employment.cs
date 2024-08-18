namespace CurriculumVitae.Shared.DtoModels;

public class Employment
{
    public Guid Id { get; set; }
    public Company Company { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
}
