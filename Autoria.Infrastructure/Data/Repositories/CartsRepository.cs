using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data.Repositories
{
    public class CartsRepository : ICartsRepository
    {
        private readonly AutoriaDbContext _context;
        public CartsRepository(AutoriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllCartsAsync()
        {
            return await _context.Carts
                .AsNoTracking()
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int cartId){

            if(cartId <= 0){
                throw new ArgumentException("CardId must be a positive integer.", nameof(cartId));
            }

            var cart = await _context.Carts
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .FirstOrDefaultAsync(c => c.Id == cartId);
            
            if(cart == null){
                throw new ArgumentException("Cart doesn't exist.", nameof(cartId));
            }

            return cart;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}