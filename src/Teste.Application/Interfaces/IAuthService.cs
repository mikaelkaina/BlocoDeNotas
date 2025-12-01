using Teste.Application.DTOs;

namespace Teste.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(AuthRequest request);
    Task<bool> RegisterAsync(AuthRequest request);
}
