using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;
using Teste.Infrastructure.Identity;
using Teste.Infrastructure.Mapping;

namespace Teste.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // 👇 DbSet padrão do Identity (explícito)
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<Note> Notes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new NoteMapping());
    }
}
