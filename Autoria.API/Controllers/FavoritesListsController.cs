using AutoMapper;
using Autoria.API.Dtos.Response;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("autoria/[controller]")]
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
        public async Task<List<FavoritesListResponseDto>> GetAllFavoritesLists(){
            var favoritesLists = await _favoritesListsService.GetAllFavoritesListsAsync();
            var favoritesListResponseDtos = favoritesLists.Select(favoritesList => _mapper.Map<FavoritesListResponseDto>(favoritesList)).ToList();
            return favoritesListResponseDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoritesListResponseDto>> GetFavoritesListById(int id){
            try
            {
                var favoritesList = await _favoritesListsService.GetFavoritesListByIdAsync(id);
                return _mapper.Map<FavoritesListResponseDto>(favoritesList);
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpPost]
        [Route("AddVehicle")]
        public async Task<IActionResult> AddItemInFavoritesListByIdAsync(int favoritesListId, int vehicleId){
            try
            {
                await _favoritesListsService.AddVehicleInFavoritesListByIdAsync(favoritesListId, vehicleId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}