using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Repositories
{
    public interface ICartsRepository
    {
        Task<Cart> GetCartByIdAsync(int cartId);
        Task<List<Cart>> GetAllCartsAsync();
        Task SaveChangesAsync();
    }
}