using Autoria.Core.Entities;

namespace Autoria.API.Dtos.Response
{
    public class CartResponseDto
    {
        public int Id { get; set; }
        public List<Vehicle> Vehicles { get; set; } = [];
        public string BuyerUsername { get; set; }
        public int BuyerId { get; set; }
    }
}