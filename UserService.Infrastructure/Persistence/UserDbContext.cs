using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Persistence;

/// <summary>
/// UserService gets its own database, per "Separate databases per microservice"
/// in the Database Requirements. No other service is allowed to reach into this DB directly.
/// </summary>
public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

        // Global soft-delete filter - every query automatically excludes IsDeleted rows.
        builder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
    }
}
