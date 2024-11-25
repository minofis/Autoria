using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Services
{
    public interface IFavoritesListsService
    {
        Task AddVehicleInFavoritesListByIdAsync(int favoritesListId, int vehicleId);
        Task RemoveVehicleFromFavoritesListByIdAsync(int favoritesListId, int vehicleId);
        Task<List<FavoritesList>> GetAllFavoritesListsAsync();
        Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId);
    }
}