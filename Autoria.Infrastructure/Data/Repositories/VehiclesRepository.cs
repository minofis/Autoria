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
                throw new ArgumentException("Vehicle doesn't exist");
            }
            return vehicle;
        }

        public async Task CreateNewVehicleAsync(Vehicle newVehicle)
        {   
            await _context.Vehicles.AddAsync(newVehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleByIdAsync(int vehicleId)
        {
            if (vehicleId <= 0)
            {
                throw new ArgumentException("VehicleId must be a positive integer", nameof(vehicleId));
            }

            bool vehicleExist = await _context.Vehicles
                .AnyAsync(v => v.Id == vehicleId);

            if (!vehicleExist)
            {
                throw new ArgumentException("Vehicle doesn't exist");
            }
            
            await _context.Vehicles
                .Where(v => v.Id == vehicleId)
                .ExecuteDeleteAsync();
        }
    }
}