using AutoMapper;
using Autoria.API.Dtos.Response;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("Autoria/[controller]")]
    public class FavoritesListsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFavoritesListsService _favoritesListsService;

        public FavoritesListsController(IFavoritesListsService favoritesListsService, IMapper mapper)
        {
            _favoritesListsService = favoritesListsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<FavoritesListResponseDto>> GetAllFavoritesLists()
        {
            // Getting all favorites lists
            var favoritesLists = await _favoritesListsService.GetAllFavoritesListsAsync();

            // Mapping all favorites lists to FavoritesListResponseDto
            return favoritesLists.Select(_mapper.Map<FavoritesListResponseDto>).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoritesListResponseDto>> GetFavoritesListById(int id)
        {
            try
            {
                // Getting favorites list by id
                var favoritesList = await _favoritesListsService.GetFavoritesListByIdAsync(id);

                // Mapping a favorites list to FavoritesListResponseDto
                return _mapper.Map<FavoritesListResponseDto>(favoritesList);
            }
            catch(Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpPost]
        [Route("AddVehicle/{id}")]
        public async Task<IActionResult> AddVehicleInFavoritesListById(int id, int vehicleId)
        {
            try
            {
                // Adding vehicle in favorites list by id
                await _favoritesListsService.AddVehicleInFavoritesListByIdAsync(id, vehicleId);
                return Ok("Vehicle is added in FavoritesList successfully");
            }
            catch(Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpDelete]
        [Route("RemoveVehicle/{id}")]
        public async Task<IActionResult> RemoveVehicleFromFavoritesListById(int id, int vehicleId)
        {
            try
            {
                // Removing vehicle from favorites list by id
                await _favoritesListsService.RemoveVehicleFromFavoritesListByIdAsync(id, vehicleId);
                return Ok("Vehicle is removed from FavoritesList successfully");
            }
            catch(Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}