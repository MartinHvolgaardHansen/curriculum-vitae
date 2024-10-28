using CurriculumVitae.Shared.DtoModels;

namespace CurriculumVitae.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<User>> Get()
    {
        return await Task.FromResult(_context.Users);
    }

    public async Task<User> Get(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}