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
            return await _context.FavoritesLists
                .AsNoTracking()
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .ToListAsync();
        }

        public async Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId){

            if(favoritesListId <= 0){
                throw new ArgumentException("FavoritesListId must be a positive integer.", nameof(favoritesListId));
            }

            var favoritesList = await _context.FavoritesLists
                .Include(c => c.Vehicles)
                .Include(c => c.Buyer)
                .FirstOrDefaultAsync(c => c.Id == favoritesListId);
            
            if(favoritesList == null){
                throw new ArgumentException("FavoritesList doesn't exist.", nameof(favoritesListId));
            }

            return favoritesList;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}