using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.DataAccess.Repositories;

public interface ICompanyRepository
{
    Task<IQueryable<Company>> Get();
    Task Add(Company company);
}