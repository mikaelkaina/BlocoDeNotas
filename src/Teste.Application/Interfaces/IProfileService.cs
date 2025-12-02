
using Teste.Application.DTOs;

namespace Teste.Application.Interfaces;

public interface IProfileService
{
    Task<UserProfileDto?> CreateProfileAsync(string userId, CreateProfileDto dto);
    Task<UserProfileDto?> GetProfileByUserAsync(string userId);
    Task<UserProfileDto?> UpdateProfileAsync(string userId, CreateProfileDto dto);
}
