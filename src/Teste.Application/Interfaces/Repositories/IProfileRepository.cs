using Teste.Domain.Entities;

namespace Teste.Application.Interfaces.Repositories;

public interface IProfileRepository
{
    Task<UserProfile?> GetByUserIdAsync(string userId);
    Task AddAsync(UserProfile profile);
    Task UpdateAsync(UserProfile profile);
}