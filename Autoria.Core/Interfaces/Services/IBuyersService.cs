using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Services
{
    public interface IBuyersService
    {
        Task<List<Buyer>> GetAllBuyersAsync();
        Task<Buyer> GetBuyerByIdAsync(int buyerId);
        Task CreateBuyerAsync(Buyer newBuyer);
    }
}