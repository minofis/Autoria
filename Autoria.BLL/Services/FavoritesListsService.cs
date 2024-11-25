using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Autoria.Core.Interfaces.Services;

namespace Autoria.BLL.Services
{
    public class FavoritesListsService : IFavoritesListsService
    {
        private readonly IFavoritesListsRepository _favoritesListsRepo;
        private readonly IVehiclesRepository _vehiclesRepo;
        public FavoritesListsService(IFavoritesListsRepository favoritesListsRepo, IVehiclesRepository vehiclesRepo)
        {
            _favoritesListsRepo = favoritesListsRepo;
            _vehiclesRepo = vehiclesRepo;
        }
        public async Task AddVehicleInFavoritesListByIdAsync(int favoritesListId, int vehicleId)
        {
            var favoritesList = await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);
            var vehicle = await _vehiclesRepo.GetVehicleByIdAsync(vehicleId);
            if (favoritesList.Vehicles.Any(v => v.Id == vehicle.Id)) throw new ArgumentException("Vehicle already exist");
            favoritesList.Vehicles.Add(vehicle);
            await _favoritesListsRepo.SaveChangesAsync();
        }

        public async Task<List<FavoritesList>> GetAllFavoritesListsAsync()
        {
            return await _favoritesListsRepo.GetAllFavoritesListsAsync();
        }

        public async Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId)
        {
            return await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);
        }

        public async Task RemoveVehicleFromFavoritesListByIdAsync(int favoritesListId, int vehicleId)
        {
            var favoritesList = await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);
            var vehicle = await _vehiclesRepo.GetVehicleByIdAsync(vehicleId);
            if (!favoritesList.Vehicles.Any(v => v.Id == vehicle.Id)) throw new ArgumentException("Vehicle doesn't exist");
            favoritesList.Vehicles.Remove(vehicle);
            await _favoritesListsRepo.SaveChangesAsync();
        }
    }
}