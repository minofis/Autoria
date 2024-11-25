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
                throw new ArgumentException("BuyerId must be a positive integer");
            }

            var buyer = await _context.Buyers
                .FirstOrDefaultAsync(b => b.Id == buyerId) ?? throw new ArgumentException("Buyer doesn't exist");
            return buyer;
        }

        public async Task CreateBuyerAsync(Buyer newBuyer)
        {
            var buyer = new Buyer{
                Username = newBuyer.Username,
                FirstName = newBuyer.FirstName,
                Surname = newBuyer.Surname,
                Email = newBuyer.Email,
                Phone = newBuyer.Phone
            };

            var favoritesList = new FavoritesList{
                Buyer = buyer,
                BuyerId = buyer.Id
            };
            await _context.Buyers.AddAsync(buyer);
            await _context.FavoritesLists.AddAsync(favoritesList);
            await _context.SaveChangesAsync();

            buyer.FavoritesListId = favoritesList.Id;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBuyerByIdAsync(int buyerId)
        {
            if (buyerId <= 0)
            {
                throw new ArgumentException("BuyerId must be a positive integer");
            }

            bool buyerExist = await _context.Buyers
                .AnyAsync(b => b.Id == buyerId);

            if (!buyerExist)
            {
                throw new ArgumentException("Buyer doesn't exist");
            }

            await _context.Buyers
                .Where(b => b.Id == buyerId)
                .ExecuteDeleteAsync();
        }
    }
}