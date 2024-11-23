using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.API.Dtos.Response;
using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("autoria/[controller]")]
    public class BuyersController : ControllerBase
    {
        private readonly IBuyersService _buyersService;
        private readonly IMapper _mapper;
        public BuyersController(IMapper mapper, IBuyersService buyersService)
        {
            _mapper = mapper;
            _buyersService = buyersService;
        }

        [HttpGet]
        public async Task<List<BuyerResponseDto>> GetAllBuyers(){
            var buyers = await _buyersService.GetAllBuyersAsync();
            var buyerResponseDtos = buyers.Select(buyer => _mapper.Map<BuyerResponseDto>(buyer)).ToList();
            return buyerResponseDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerResponseDto>> GetBuyerById(int id){
            try
            {
            var buyer = await _buyersService.GetBuyerByIdAsync(id);
            return _mapper.Map<BuyerResponseDto>(buyer);
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateBuyer(BuyerRequestDto buyerDto){
            try
            {
            await _buyersService.CreateBuyerAsync(_mapper.Map<Buyer>(buyerDto));
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}