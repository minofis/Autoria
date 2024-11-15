using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Repositories
{
    public interface IBuyersRepository
    {
        Task<List<Buyer>> GetAllBuyersAsync();
        Task<Buyer> GetBuyerByIdAsync(int buyerId);
        Task CreateBuyerAsync(Buyer buyer);
    }
}