using Autoria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoria.Infrastructure.Data.Configurations
{
    public class FavoritesListConfiguration : IEntityTypeConfiguration<FavoritesList>
    {
        public void Configure(EntityTypeBuilder<FavoritesList> builder)
        {
            builder
                .HasOne(c => c.Buyer)
                .WithOne(b => b.FavoritesList)
                .HasForeignKey<Buyer>(b => b.FavoritesListId);
        }
    }
}