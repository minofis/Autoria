using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.API.Dtos.Response;
using Autoria.Core.Entities;

namespace Autoria.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            CreateMap<BuyerRequestDto, Buyer>()
            .ForMember(d => d.Name, s => s.MapFrom(x => x.Name))
            .ForMember(d => d.Surname, s => s.MapFrom(x => x.Surname))
            .ForMember(d => d.Email, s => s.MapFrom(x => x.Email))
            .ForMember(d => d.Phone, s => s.MapFrom(x => x.Phone));

            CreateMap<VehicleRequestDto, Vehicle>()
            .ForMember(d => d.Type, s => s.MapFrom(x => x.Type))
            .ForMember(d => d.Brand, s => s.MapFrom(x => x.Brand))
            .ForMember(d => d.Model, s => s.MapFrom(x => x.Model))
            .ForMember(d => d.Year, s => s.MapFrom(x => x.Year))
            .ForMember(d => d.EngineCapacity, s => s.MapFrom(x => x.EngineCapacity))
            .ForMember(d => d.Price, s => s.MapFrom(x => x.Price));

            CreateMap<Cart, CartResponseDto>()
            .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
            .ForMember(d => d.BuyerUsername, s => s.MapFrom(x => x.Buyer.Username))
            .ForMember(d => d.BuyerId, s => s.MapFrom(x => x.BuyerId))
            .ForMember(d => d.Vehicles, s => s.MapFrom(x => x.Vehicles));

            CreateMap<Buyer, BuyerResponseDto>()
            .ForMember(d => d.Id, s => s.MapFrom(x => x.Id))
            .ForMember(d => d.Name, s => s.MapFrom(x => x.Name))
            .ForMember(d => d.Surname, s => s.MapFrom(x => x.Surname))
            .ForMember(d => d.Email, s => s.MapFrom(x => x.Email))
            .ForMember(d => d.Phone, s => s.MapFrom(x => x.Phone))
            .ForMember(d => d.CartId, s => s.MapFrom(x => x.CartId));
        }
    }
}