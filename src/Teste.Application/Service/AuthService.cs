using Teste.Application.DTOs;
using Teste.Application.Interfaces.Identity;

namespace Teste.Application.Services;

public class AuthService : IAuthService
{
    private readonly IIdentityAuthService _identityAuthService;
    private readonly ITokenService _tokenService;

    public AuthService(
        IIdentityAuthService identityAuthService,
        ITokenService tokenService)
    {
        _identityAuthService = identityAuthService;
        _tokenService = tokenService;
    }

    public async Task<bool> RegisterAsync(AuthRequest request)
    {
        return await _identityAuthService.RegisterAsync(
            request.Email,
            request.Password);
    }

    public async Task<AuthResponse?> LoginAsync(AuthRequest request)
    {
        var userId = await _identityAuthService.ValidateUserAsync(
            request.Email,
            request.Password);

        if (userId is null)
            return null;

        return _tokenService.GenerateToken(userId, request.Email);
    }
}
