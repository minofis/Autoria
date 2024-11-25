using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("Autoria/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _vehiclesService;
        private readonly IMapper _mapper;

        public VehiclesController(IVehiclesService vehiclesService, IMapper mapper)
        {
            _vehiclesService = vehiclesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _vehiclesService.GetAllVehiclesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            try
            {
                var vehicle = await _vehiclesService.GetVehicleByIdAsync(id);
                return vehicle;
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNewVehicle(VehicleRequestDto vehicleDto)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleDto);
                await _vehiclesService.CreateNewVehicleAsync(vehicle);
                return Ok("Vehicle is created successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            try
            {
                await _vehiclesService.DeleteVehicleByIdAsync(id);
                return Ok("Vehicle is deleted successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}