using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;
using Teste.Infrastructure.Identity;

namespace Teste.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // 👇 DbSet padrão do Identity (explícito)
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
}
