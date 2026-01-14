using Microsoft.EntityFrameworkCore;
using Teste.Application.Interfaces.Repositories;
using Teste.Domain.Entities;
using Teste.Infrastructure.Data;

namespace Teste.Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Note note)
    {
        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Note note)
    {
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Note note)
    {
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
    }

    public async Task<Note?> GetByIdAsync(Guid id)
    {
        return await _context.Notes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Note>> GetByUserAsync(string userId)
    {
        return await _context.Notes
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}