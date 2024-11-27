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
            // Creating a new vehicle in VehiclesFactory
            var vehicle = _vehiclesFactory.CreateVehicle(newVehicle);

            // Creating a vehicle
            await _vehiclesRepo.CreateNewVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleByIdAsync(int vehicleId)
        {
            // Deleting a vehicle
            await _vehiclesRepo.DeleteVehicleByIdAsync(vehicleId);
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            // Getting all vehicles
            return await _vehiclesRepo.GetAllVehiclesAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            // Getting a vehicle by id
            return await _vehiclesRepo.GetVehicleByIdAsync(id);
        }
    }
}