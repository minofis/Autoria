using Autoria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoria.Infrastructure.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
            .HasDiscriminator<string>("VehicleType")
            .HasValue<NewCar>("NewCar")
            .HasValue<UsedCar>("UsedCar")
            .HasValue<Motorcycle>("Motorcycle")
            .HasValue<SpecialMachinery>("SpecialMachinery");
        }
    }
}