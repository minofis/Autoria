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

        public virtual Vehicle Create(Vehicle newVehicle)
        {
            return new Vehicle
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                };
        }
    }
}