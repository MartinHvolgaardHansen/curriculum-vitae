namespace CurriculumVitae.Shared.DtoModels;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ContactInformation ContactInformation { get; set; }
    
}