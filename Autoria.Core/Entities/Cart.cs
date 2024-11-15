namespace Autoria.Core.Entities
{
    public class Cart : BaseEntity
    {
        public List<Vehicle> Vehicles { get; set; } = [];
        public Buyer Buyer { get; set; }
        public int BuyerId { get; set; }
    }
}