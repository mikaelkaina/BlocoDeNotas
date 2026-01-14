using System.Net.Http.Json;
using Teste.Ui.Models.Notes;

namespace Teste.Ui.Services;

public class NoteApiService
{
    private readonly HttpClient _httpClient;
    public NoteApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<NoteDto>> GetMyNotes()
    {
        return await _httpClient.GetFromJsonAsync<List<NoteDto>>("api/notes")
               ?? new List<NoteDto>();
    }

    public async Task CreateAsync(CreateNoteDto dto)
    {
        await _httpClient.PostAsJsonAsync("api/notes", dto);
    }

    public async Task UpdateAsync(Guid id, CreateNoteDto dto)
    {
        await _httpClient.PutAsJsonAsync($"api/notes/{id}", dto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/notes/{id}");
    }
}