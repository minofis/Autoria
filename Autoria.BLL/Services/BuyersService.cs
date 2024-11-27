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
            // Checking if a buyer exists with the current Email, Phone, Username
            var buyers = await _buyersRepo.GetAllBuyersAsync();
            if (buyers.Any(b => b.Email == newBuyer.Email)) throw new ArgumentException("Buyer with this Email already exists");
            if(buyers.Any(b => b.Phone == newBuyer.Phone)) throw new ArgumentException("Buyer with this Phone already exists");
            if(buyers.Any(b => b.Username == newBuyer.Username)) throw new ArgumentException("Buyer with this Username already exists");

            // Creating a new buyer
            await _buyersRepo.CreateBuyerAsync(newBuyer);
        }

        public async Task DeleteBuyerByIdAsync(int buyerId)
        {
            // Deleting a new buyer
            await _buyersRepo.DeleteBuyerByIdAsync(buyerId);
        }

        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            // Getting all buyers
            return await _buyersRepo.GetAllBuyersAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            // Getting a buyer by id
            return await _buyersRepo.GetBuyerByIdAsync(buyerId);
        }
    }
}