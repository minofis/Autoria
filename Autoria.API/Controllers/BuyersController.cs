using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.API.Dtos.Response;
using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("Autoria/[controller]")]
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
        public async Task<ActionResult<List<BuyerResponseDto>>> GetAllBuyers()
        {
            var buyers = await _buyersService.GetAllBuyersAsync();
            var buyerResponseDtos = buyers.Select(_mapper.Map<BuyerResponseDto>).ToList();
            return buyerResponseDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerResponseDto>> GetBuyerById(int id)
        {
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
        public async Task<IActionResult> CreateBuyer(BuyerRequestDto buyerDto)
        {
            try
            {
            await _buyersService.CreateBuyerAsync(_mapper.Map<Buyer>(buyerDto));
            return Ok("Buyer is created successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteBuyerById(int id)
        {
            try
            {
                await _buyersService.DeleteBuyerByIdAsync(id);
                return Ok("Buyer is deleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}