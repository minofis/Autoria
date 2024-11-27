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

        public async Task<List<FavoritesList>> GetAllFavoritesListsAsync()
        {
            // Getting all favorites lists
            return await _favoritesListsRepo.GetAllFavoritesListsAsync();
        }

        public async Task<FavoritesList> GetFavoritesListByIdAsync(int favoritesListId)
        {
            // Getting a favorites list by id
            return await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);
        }

        public async Task AddVehicleInFavoritesListByIdAsync(int favoritesListId, int vehicleId)
        {
            // Getting a favorites list by id
            var favoritesList = await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);

            // Getting a vehicle by id
            var vehicle = await _vehiclesRepo.GetVehicleByIdAsync(vehicleId);

            // Check if a vehicle is in the current favorites list
            if (favoritesList.Vehicles.Any(v => v.Id == vehicle.Id)) 
                throw new ArgumentException("Vehicle is already exist in the favorites list");

            // Adding a vehicle to favorites list
            favoritesList.Vehicles.Add(vehicle);
            await _favoritesListsRepo.SaveChangesAsync();
        }

        public async Task RemoveVehicleFromFavoritesListByIdAsync(int favoritesListId, int vehicleId)
        {
            // Getting a favorites list by id
            var favoritesList = await _favoritesListsRepo.GetFavoritesListByIdAsync(favoritesListId);

            // Getting a vehicle by id
            var vehicle = await _vehiclesRepo.GetVehicleByIdAsync(vehicleId);

            // Check if a vehicle isn't in the current favorites list
            if (!favoritesList.Vehicles.Any(v => v.Id == vehicle.Id)) 
                throw new ArgumentException("Vehicle doesn't exist in the favorites list");

            // Removing a vehicle from favorites list
            favoritesList.Vehicles.Remove(vehicle);
            await _favoritesListsRepo.SaveChangesAsync();
        }
    }
}