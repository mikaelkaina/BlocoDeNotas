using System.Net.Http.Json;
using Teste.Ui.Models;

namespace Teste.Ui.Services;

public class ProfileService
{
    private readonly HttpClient _httpClient;
    public ProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserProfileDto?> GetProfileAsync()
    {
        var response = await _httpClient.GetAsync("api/profile");
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<UserProfileDto>();

        return null;
    }

    public async Task<bool> CreateProfileAsync(CreateProfileDto dto)
    {
        var respose = await _httpClient.PostAsJsonAsync("api/profile", dto);
        return respose.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProfileAsync(CreateProfileDto dto)
    {
        var respose = await _httpClient.PutAsJsonAsync("api/profile", dto);
        if (!respose.IsSuccessStatusCode) return false;
        return respose.IsSuccessStatusCode;
    }
}
