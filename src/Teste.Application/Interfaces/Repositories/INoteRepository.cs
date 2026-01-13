using Teste.Domain.Entities;

namespace Teste.Application.Interfaces.Repositories;

public interface INoteRepository
{
    Task AddAsync(Note note);
    Task UpdateAsync(Note note);
    Task DeleteAsync(Note note);

    Task<Note?> GetByIdAsync(Guid id);
    Task<IEnumerable<Note>> GetByUserAsync(string userId);
}