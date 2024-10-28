using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.DataAccess.Repositories;

public interface IUserRepository
{
    Task<IQueryable<User>> Get();
    Task<User> Get(Guid id);
    Task Add(User user);
}