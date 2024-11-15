using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Autoria.API.Controllers
{
    [ApiController]
    [Route("Autoria/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehiclesRepository _vehiclesRepo;

        public VehiclesController(IVehiclesRepository vehiclesRepo, IMapper mapper)
        {
            _vehiclesRepo = vehiclesRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _vehiclesRepo.GetAllVehiclesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Vehicle> GetVehicleById(int id){
            return await _vehiclesRepo.GetVehicleByIdAsync(id);
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateNewVehicle(VehicleRequestDto vehicleDto)
        {
            await _vehiclesRepo.CreateNewVehicleAsync(_mapper.Map<Vehicle>(vehicleDto));
        }
    }
}