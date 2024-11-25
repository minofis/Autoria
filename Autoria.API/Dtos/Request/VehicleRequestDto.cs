using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoria.API.Dtos.Request
{
    public class VehicleRequestDto
    {
        [DefaultValue("")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1991, 2024, ErrorMessage = "")]
        public int Year { get; set; }
        [Required(ErrorMessage = "EngineCapacity is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public int EngineCapacity { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
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