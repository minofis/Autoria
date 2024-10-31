using Autoria.Core.Entities;
using Autoria.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data
{
    public class AutoriaDbContext : DbContext
    {
        public AutoriaDbContext(DbContextOptions<AutoriaDbContext> options) : base(options)
        {
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<NewCar> NewCars { get; set; }
        public DbSet<UsedCar> UsedCars { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<SpecialMachinery> SpecialMachineries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}