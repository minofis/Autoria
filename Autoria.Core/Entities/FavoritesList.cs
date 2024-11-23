namespace Autoria.Core.Entities
{
    public class FavoritesList : BaseEntity
    {
        public List<Vehicle> Vehicles { get; set; } = [];
        public Buyer Buyer { get; set; }
        public int BuyerId { get; set; }
    }
}