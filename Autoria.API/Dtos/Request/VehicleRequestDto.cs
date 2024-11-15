using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Autoria.API.Dtos.Request
{
    public class VehicleRequestDto
    {
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int EngineCapacity { get; set; }
        public decimal Price { get; set; }
        public int? Mileage { get; set; }
    }
}