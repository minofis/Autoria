using Autoria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoria.Infrastructure.Data.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder
                .HasOne(b => b.Cart)
                .WithOne(c => c.Buyer)
                .HasForeignKey<Cart>(c => c.BuyerId);
        }
    }
}