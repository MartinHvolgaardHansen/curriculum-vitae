namespace CurriculumVitae.Shared.DtoModels;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ContactInformation ContactInformation { get; set; }
}