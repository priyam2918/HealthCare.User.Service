using BuildingBlocks.Common.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
}
