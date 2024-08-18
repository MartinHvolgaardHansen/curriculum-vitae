using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.Domain.Services;

public interface ICompanyService
{
    Task<IEnumerable<Company>> Get();
}