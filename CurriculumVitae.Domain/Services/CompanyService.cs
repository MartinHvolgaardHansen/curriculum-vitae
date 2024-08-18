
using CurriculumVitae.DataAccess.Repositories;
using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.Domain.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IEnumerable<Company>> Get()
    {
        return await _companyRepository.Get();
        // return await Task.FromResult(new List<Company>
        // {
        //     new ()
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "MyCompany",
        //         ContactInformation = new ()
        //         {
        //             Id = Guid.NewGuid(),
        //             Email = "MyEmail",
        //             Phones = new List<Phone>{ new () { Id = Guid.NewGuid(), PhoneNumber = "12345678", CountryCode = "+45" } },
        //             AddressLineOne = "MyAddress",
        //             City = "MyCity",
        //             Country = "MyCountry"
        //         }
        //     }
        // });
    }

    public Task Add(Company company)
    {
        return _companyRepository.Add(company);
    }
}