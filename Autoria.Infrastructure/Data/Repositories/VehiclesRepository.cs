using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data.Repositories
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly AutoriaDbContext _context;

        public VehiclesRepository(AutoriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            if (vehicleId <= 0)
            {
                throw new ArgumentException("VehicleId must be a positive integer", nameof(vehicleId));
            }
            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                throw new ArgumentException("Vehicle doesn't exist.", nameof(vehicleId));
            }
            return vehicle;
        }

        public async Task CreateNewVehicleAsync(Vehicle newVehicle)
        {
            var vehicleFactory = new VehiclesFactory();

            Vehicle vehicle = vehicleFactory.CreateVehicle(newVehicle);
            
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}