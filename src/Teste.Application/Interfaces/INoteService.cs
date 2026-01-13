using Teste.Application.DTOs.Notes;

namespace Teste.Application.Interfaces;

public interface INoteService
{
    Task<NoteDto> CreateAsync(string userId, CreateNoteDto dto);
    Task<IEnumerable<NoteDto>> GetByUserAsync(string userId);
    Task<bool> UpdateAsync(string userId, Guid noteId, CreateNoteDto dto);
    Task<bool> DeleteAsync(string userId, Guid noteId);
}