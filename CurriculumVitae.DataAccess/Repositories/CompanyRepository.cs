using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.DataAccess.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<Company>> Get()
    {
        // Do something else async, e.g. IAsyncEnumerable
        return await Task.FromResult(_context.Companies);
    }
}