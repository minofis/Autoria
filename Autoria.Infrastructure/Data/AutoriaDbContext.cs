using Autoria.Core.Entities;
using Autoria.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data
{
    public class AutoriaDbContext : DbContext
    {
        public AutoriaDbContext(DbContextOptions<AutoriaDbContext> options) : base(options){}

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}