using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.Core.Entities;

namespace Autoria.API.Helpers.AutoMapper
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleRequestDto, Vehicle>();
        }
    }
}