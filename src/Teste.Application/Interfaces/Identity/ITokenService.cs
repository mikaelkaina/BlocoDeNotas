using Teste.Application.DTOs;

namespace Teste.Application.Interfaces.Identity;

public interface ITokenService
{
    AuthResponse GenerateToken(string userId, string userName);
}
