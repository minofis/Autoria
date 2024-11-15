using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Repositories
{
    public interface IVehiclesRepository
    {
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task CreateNewVehicleAsync(Vehicle vehicle);
    }
}