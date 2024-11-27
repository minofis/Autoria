using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Autoria.Infrastructure.Data.Repositories
{
    public class FavoritesListsRepository : IFavoritesListsRepository
    {
        private readonly AutoriaDbContext _context;
        public FavoritesListsRepository(AutoriaDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavoritesList>> GetAllFavoritesListsAsync()
        {
            // Getting all favorites lists
            return await _context.FavoritesLists
                .AsNoTracking()
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .ToListAsync();
        }

        public async Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId){

            // Check if favoritesListId is 0
            if (favoritesListId <= 0) throw new ArgumentException("FavoritesListId must be a positive integer");

            // Getting favorites list by id
            return await _context.FavoritesLists
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .FirstOrDefaultAsync(c => c.Id == favoritesListId) 
                    // Check is favorites list exists
                    ?? throw new ArgumentException("FavoritesList doesn't exist");
        }
        
        public async Task DeleteFavoritesListByIdAsync(int favoritesListId)
        {
            // Check if favoritesListId is 0
            if (favoritesListId <= 0) throw new ArgumentException("FavoritesListId must be a positive integer");

            // Check is favorites list exists
            bool favoritesListExist = await _context.FavoritesLists
                .AnyAsync(f => f.Id == favoritesListId);
            if (!favoritesListExist) throw new ArgumentException("FavoritesList doesn't exist");
            
            // Deleting favorites list by id
            await _context.FavoritesLists
                .Where(f => f.Id == favoritesListId)
                .ExecuteDeleteAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}