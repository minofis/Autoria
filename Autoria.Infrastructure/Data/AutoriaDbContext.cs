using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data
{
    public class AutoriaDbContext : DbContext
    {
        public AutoriaDbContext(DbContextOptions<AutoriaDbContext>) : base(options)
        {
        }
    }
}