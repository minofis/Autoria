using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Services
{
    public interface ICartsService
    {
        Task AddVehicleInCartByIdAsync(int cartId, int vehicleId);
        Task<List<Cart>> GetAllCartsAsync();
        Task<Cart> GetCartByIdAsync(int cartId);
    }
}