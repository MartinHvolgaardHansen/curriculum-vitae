namespace CurriculumVitae.Shared.DtoModels;

public class ContactInformation
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<Phone> Phones { get; set; }
    public string AddressLineOne { get; set; }
    public string AddressLineTwo { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
}