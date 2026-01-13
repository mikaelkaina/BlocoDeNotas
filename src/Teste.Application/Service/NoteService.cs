using Teste.Application.DTOs.Notes;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Repositories;
using Teste.Domain.Entities;

namespace Teste.Application.Service;

public class NoteService : INoteService
{
    private readonly INoteRepository _repository;

    public NoteService(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<NoteDto> CreateAsync(string userId, CreateNoteDto dto)
    {
        var note = new Note(userId, dto.Title, dto.Content);

        await _repository.AddAsync(note);

        return Map(note);
    }

    public async Task<IEnumerable<NoteDto>> GetByUserAsync(string userId)
    {
        var notes = await _repository.GetByUserAsync(userId);
        return notes.Select(Map);
    }

    public async Task<bool> UpdateAsync(string userId, Guid noteId, CreateNoteDto dto)
    {
        var note = await _repository.GetByIdAsync(noteId);
        if (note == null || note.UserId != userId)
            return false;

        note.Update(dto.Title, dto.Content);

        await _repository.UpdateAsync(note);
        return true;
    }

    public async Task<bool> DeleteAsync(string userId, Guid noteId)
    {
        var note = await _repository.GetByIdAsync(noteId);
        if (note == null || note.UserId != userId)
            return false;

        await _repository.DeleteAsync(note);
        return true;
    }

    private static NoteDto Map(Note note)
    {
        return new NoteDto
        {
            Id = note.Id,
            Title = note.Title,
            Content = note.Content,
            CreatedAt = note.CreatedAt
        };
    }
}