
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
                Name = "MyCompany"
            }
        });

    }
}