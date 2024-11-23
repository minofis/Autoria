using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Factories;
using Autoria.Core.Interfaces.Repositories;
using Autoria.Core.Interfaces.Services;

namespace Autoria.BLL.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _vehiclesRepo;
        private readonly IVehiclesFactory _vehiclesFactory;
        public VehiclesService(IVehiclesRepository vehiclesRepo, IVehiclesFactory vehiclesFactory)
        {
            _vehiclesRepo = vehiclesRepo;
            _vehiclesFactory = vehiclesFactory;
        }
        public async Task CreateNewVehicleAsync(Vehicle newVehicle)
        {
            var vehicle = _vehiclesFactory.CreateVehicle(newVehicle);
            await _vehiclesRepo.CreateNewVehicleAsync(vehicle);
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehiclesRepo.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _vehiclesRepo.GetVehicleByIdAsync(id);
        }
    }
}