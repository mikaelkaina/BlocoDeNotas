using Microsoft.AspNetCore.Identity;
using Teste.Application.Interfaces.Identity;
using Teste.Domain.Entities;

namespace Teste.Infrastructure.Identity.Service;

public class IdentityAuthService : IIdentityAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityAuthService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> RegisterAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<string?> ValidateUserAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return null;

        var valid = await _userManager.CheckPasswordAsync(user, password);
        return valid ? user.Id : null;
    }
}
