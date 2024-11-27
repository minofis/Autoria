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
            // Getting all vehicles
            return await _vehiclesService.GetAllVehiclesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            try
            {
                // Getting a vehicle by id
                return await _vehiclesService.GetVehicleByIdAsync(id);
            }
            catch (Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNewVehicle(VehicleRequestDto vehicleDto)
        {
            try
            {   // Creating a new vehicle
                await _vehiclesService.CreateNewVehicleAsync(
                    // Mapping a VehicleRequestDto to vehicle
                    _mapper.Map<Vehicle>(vehicleDto));
                return Ok("Vehicle is created successfully");
            }
            catch(Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteVehicleById(int id)
        {
            try
            {
                // Deleting a vehicle by id
                await _vehiclesService.DeleteVehicleByIdAsync(id);
                return Ok("Vehicle is deleted successfully");
            }
            catch(Exception ex)
            {
                // Error output
                return BadRequest(new {error = ex.Message});
            }
        }
    }
}