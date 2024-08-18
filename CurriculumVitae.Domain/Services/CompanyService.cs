
using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.Domain.Services;

public class CompanyService : ICompanyService
{
    public async Task<IEnumerable<Company>> Get()
    {
        return await Task.FromResult(new List<Company>
        {
            new ()
            {
                Id = Guid.NewGuid(),
                Name = "MyCompany",
                ContactInformation = new ()
                {
                    Id = Guid.NewGuid(),
                    Email = "MyEmail",
                    Phones = new List<Phone>{ new () { Id = Guid.NewGuid(), PhoneNumber = "12345678", CountryCode = "+45" } },
                    AddressLineOne = "MyAddress",
                    City = "MyCity",
                    Country = "MyCountry"
                }
            }
        });

    }
}