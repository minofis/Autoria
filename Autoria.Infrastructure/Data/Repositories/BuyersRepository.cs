using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data.Repositories
{
    public class BuyersRepository : IBuyersRepository
    {
        private readonly AutoriaDbContext _context;
        public BuyersRepository(AutoriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Buyer>> GetAllBuyersAsync(){
            return await _context.Buyers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId){

            if(buyerId <= 0){
                throw new ArgumentException("BuyerId must be a positive integer.", nameof(buyerId));
            }

            var buyer = await _context.Buyers
                .FirstOrDefaultAsync(c => c.Id == buyerId);
            
            if(buyer == null){
                throw new ArgumentException("Buyer doesn't exist.", nameof(buyerId));
            }

            return buyer;
        }

        public async Task CreateBuyerAsync(Buyer newBuyer)
        {
            var buyer = new Buyer{
                Username = newBuyer.Username,
                Name = newBuyer.Name,
                Surname = newBuyer.Surname,
                Email = newBuyer.Email,
                Phone = newBuyer.Phone
            };

            var cart = new Cart{
                Buyer = buyer,
                BuyerId = buyer.Id
            };
            await _context.Buyers.AddAsync(buyer);
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            buyer.CartId = cart.Id;
            await _context.SaveChangesAsync();
        }
    }
}