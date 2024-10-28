using CurriculumVitae.Shared.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVitae.DataAccess;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=../CurriculumVitae.DataAccess/cvdb.sqlite");
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
}