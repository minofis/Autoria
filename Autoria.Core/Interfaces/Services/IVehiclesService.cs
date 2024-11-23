using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Services
{
    public interface IVehiclesService
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task CreateNewVehicleAsync(Vehicle newVehicle);
    }
}