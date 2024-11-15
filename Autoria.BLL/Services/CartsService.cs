using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Autoria.Core.Interfaces.Services;

namespace Autoria.BLL.Services
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepo;
        private readonly IVehiclesRepository _vehiclesRepo;
        public CartsService(ICartsRepository cartsRepo, IVehiclesRepository vehiclesRepo)
        {
            _cartsRepo = cartsRepo;
            _vehiclesRepo = vehiclesRepo;
        }
        public async Task AddVehicleInCartByIdAsync(int cartId, int vehicleId)
        {
            var cart = await _cartsRepo.GetCartByIdAsync(cartId);
            var item = await _vehiclesRepo.GetVehicleByIdAsync(vehicleId);

            cart.Vehicles.Add(item);
            await _cartsRepo.SaveChangesAsync();
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _cartsRepo.GetAllCartsAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int cartId)
        {
            return await _cartsRepo.GetCartByIdAsync(cartId);
        }
    }
}