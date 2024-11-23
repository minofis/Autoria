using AutoMapper;
using Autoria.API.Dtos.Response;
using Autoria.Core.Entities;

namespace Autoria.API.Helpers.AutoMapper
{
    public class FavoritesListProfile : Profile
    {
        public FavoritesListProfile()
        {
            CreateMap<FavoritesList, FavoritesListResponseDto>();
        }
    }
}