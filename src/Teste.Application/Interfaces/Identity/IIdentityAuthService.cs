namespace Teste.Application.Interfaces.Identity;

public interface IIdentityAuthService
{
    Task<bool> RegisterAsync(string email, string password);
    Task<string?> ValidateUserAsync(string email, string password);
}
