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

        public async Task<List<Buyer>> GetAllBuyersAsync()
        {
            // Getting all buyers
            return await _context.Buyers
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(int buyerId)
        {
            // Check if buyerId is 0
            if(buyerId <= 0) throw new ArgumentException("BuyerId must be a positive integer");

            // Getting buyer by id
            return await _context.Buyers
                .FirstOrDefaultAsync(b => b.Id == buyerId) 
                    // Check is buyer exists
                    ?? throw new ArgumentException("Buyer doesn't exists");
        }

        public async Task CreateBuyerAsync(Buyer newBuyer)
        {
            // Creating new buyer
            var buyer = Buyer.CreateBuyer(newBuyer);

            // Creating new favorites list
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
                throw new ArgumentException("Buyer doesn't exists");
            }

            await _context.Buyers
                .Where(b => b.Id == buyerId)
                .ExecuteDeleteAsync();
        }
    }
}