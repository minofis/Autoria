using System.ComponentModel;

namespace Autoria.API.Dtos.Request
{
    public class VehicleRequestDto
    {
        [DefaultValue("")]
        public string Type { get; set; }
        [DefaultValue("")]
        public string Brand { get; set; }
        [DefaultValue("")]
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineCapacity { get; set; }
        public decimal Price { get; set; }

        //UsedCar fields
        public int? Mileage { get; set; }

        //SpecialMachinery fields
        [DefaultValue("")]
        public string? Category { get; set; }
        public int? LoadCapacity { get; set; }

        //Motorcycle fields
        [DefaultValue("")]
        public string? EngineType { get; set; }
    }
}