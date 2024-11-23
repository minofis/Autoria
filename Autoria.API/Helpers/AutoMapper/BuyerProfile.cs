using AutoMapper;
using Autoria.API.Dtos.Request;
using Autoria.API.Dtos.Response;
using Autoria.Core.Entities;

namespace Autoria.API.Helpers.AutoMapper
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<BuyerRequestDto, Buyer>();
            
            CreateMap<Buyer, BuyerResponseDto>();
        }
    }
}