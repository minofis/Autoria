namespace Autoria.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineCapacity { get; set; }
        public decimal Price { get; set; }
    }
}