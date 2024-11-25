using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Repositories
{
    public interface IFavoritesListsRepository
    {
        Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId);
        Task<List<FavoritesList>> GetAllFavoritesListsAsync();
        Task SaveChangesAsync();
        Task DeleteFavoritesListByIdAsync(int favoritesListId);
    }
}