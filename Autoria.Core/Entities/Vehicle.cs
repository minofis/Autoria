namespace Autoria.Core.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int EngineCapacity { get; set; }
        public decimal Price { get; set; }

        //UsedCar fields
        public int? Mileage { get; set; } = null;

        //SpecialMachinery fields
        public string? Category { get; set; } = null;
        public int? LoadCapacity { get; set; } = null;

        //Motorcycle fields
        public string? EngineType { get; set; } = null;
    }
}