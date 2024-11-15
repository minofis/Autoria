using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Autoria.Core.Interfaces.Services;

namespace Autoria.BLL.Services
{
    public class BuyersService : IBuyersService
    {
        private readonly IBuyersRepository _buyersRepo;
        public BuyersService(IBuyersRepository buyersRepo)
        {
            _buyersRepo = buyersRepo;
        }
        public async Task CreateBuyerAsync(Buyer newBuyer)
        {
            await _buyersRepo.CreateBuyerAsync(newBuyer);
        }

        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            return await _buyersRepo.GetAllBuyersAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            return await _buyersRepo.GetBuyerByIdAsync(buyerId);
        }
    }
}