using AutoMapper;
using Autoria.API.Dtos.Response;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("autoria/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICartsService _cartsService;

        public CartsController(ICartsService cartsService, IMapper mapper)
        {
            _cartsService = cartsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CartResponseDto>> GetAllCarts(){
            var carts = await _cartsService.GetAllCartsAsync();
            var cartResponseDtos = carts.Select(cart => _mapper.Map<CartResponseDto>(cart)).ToList();
            return cartResponseDtos;
        }

        [HttpGet("{id}")]
        public async Task<CartResponseDto> GetCartById(int id){
            var cart = await _cartsService.GetCartByIdAsync(id);
            return _mapper.Map<CartResponseDto>(cart);
        }

        [HttpPost]
        [Route("AddVehicle")]
        public async Task AddItemInCartByIdAsync(int cartId, int vehicleId){
            await _cartsService.AddVehicleInCartByIdAsync(cartId, vehicleId);
        }
    }
}