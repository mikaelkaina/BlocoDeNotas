using BlocoDeNotas.Models;
using Microsoft.EntityFrameworkCore;

namespace BlocoDeNotas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Nota> Notas { get; set; }
    }
}
