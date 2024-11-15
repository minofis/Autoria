using Autoria.Core.Entities;
using Autoria.Core.Interfaces;

namespace Autoria.Infrastructure.Data
{
    public class VehiclesFactory : IVehiclesFactory
    {
        public Vehicle CreateVehicle(Vehicle newVehicle)
        {
            Vehicle vehicle;
            switch (newVehicle.Type)
            {
                case "NewCar":
                vehicle = new NewCar
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price
                };
                break;
                case "UsedCar": 
                vehicle = new UsedCar{
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                    Mileage = ((UsedCar)newVehicle).Mileage
                };
                break;
                case "Motorcycle": 
                vehicle = new Motorcycle
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price
                };
                break;
                case "SpecialMachinery": 
                vehicle = new SpecialMachinery
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                    Category = ((SpecialMachinery)newVehicle).Category
                };
                break;
                default:
                    throw new ArgumentException("Unsupported vehicle type", newVehicle.Type);
            }
            return vehicle;
        }
    }
}