
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
    }

    public Task Add(Company company)
    {
        return _companyRepository.Add(company);
    }
}