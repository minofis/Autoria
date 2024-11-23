using Autoria.Core.Entities;

namespace Autoria.API.Dtos.Response
{
    public class FavoritesListResponseDto
    {
        public int Id { get; set; }
        public List<Core.Entities.Vehicle> Vehicles { get; set; } = [];
        public string BuyerUsername { get; set; }
        public int BuyerId { get; set; }
    }
}