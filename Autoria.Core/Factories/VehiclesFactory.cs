using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Factories;

namespace Autoria.Core.Factories
{
    public class VehiclesFactory : IVehiclesFactory
    {
        public Vehicle CreateVehicle(Vehicle newVehicle)
        {
            if(newVehicle == null)
            {
                throw new ArgumentException(nameof(newVehicle));
            }

            ValidateCommonFields(newVehicle);

            Vehicle vehicle;

            switch (newVehicle.Type)
            {
                case "NewCar":
                ValidateNewCar(newVehicle);
                vehicle = new Vehicle
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
                ValidateUsedCar(newVehicle);
                vehicle = new Vehicle
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                    Mileage = newVehicle.Mileage
                };
                break;
                case "Motorcycle":
                ValidateMotorcycle(newVehicle);
                vehicle = new Vehicle
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                    EngineType = newVehicle.EngineType
                };
                break;
                case "SpecialMachinery": 
                ValidateSpecialMachinery(newVehicle);
                vehicle = new Vehicle
                {
                    Type = newVehicle.Type,
                    Brand = newVehicle.Brand,
                    Model = newVehicle.Model,
                    Year = newVehicle.Year,
                    EngineCapacity = newVehicle.EngineCapacity,
                    Price = newVehicle.Price,
                    Category = newVehicle.Category,
                    LoadCapacity = newVehicle.LoadCapacity
                };
                break;
                default:
                    throw new ArgumentException("Unsupported vehicle type", nameof(newVehicle.Type));
            }
            return vehicle;
        }

        private void ValidateCommonFields(Vehicle newVehicle){
            if (string.IsNullOrEmpty(newVehicle.Brand)||
                string.IsNullOrEmpty(newVehicle.Model)||
                newVehicle.Year <= 0 ||
                newVehicle.EngineCapacity <= 0 ||
                newVehicle.Price == 0)
            {
                throw new ArgumentException("Fields Brand, Model, Year, EngineCapacity, Price can't be empty.");
            }
        }

        private void ValidateNewCar(Vehicle newVehicle){
            if (newVehicle.Mileage > 0 ||
                    newVehicle.LoadCapacity > 0 ||
                    !string.IsNullOrEmpty(newVehicle.EngineType) || 
                    !string.IsNullOrEmpty(newVehicle.Category))
                {
                    throw new ArgumentException("Fields Mileage, EngineType, Category, LoadCapacity must be empty for a NewCar.");
                }
        }
        private void ValidateUsedCar(Vehicle newVehicle){
            if (newVehicle.LoadCapacity > 0 ||
                    !string.IsNullOrEmpty(newVehicle.EngineType) || 
                    !string.IsNullOrEmpty(newVehicle.Category))
                {
                    throw new ArgumentException("Fields EngineType, Category, LoadCapacity must be empty for a UsedCar.");
                } else if(newVehicle.Mileage == 0){
                    throw new ArgumentException("Mileage field can't equals 0 for a UsedCar.");
                }
        }

        private void ValidateMotorcycle(Vehicle newVehicle){
            if (newVehicle.Mileage > 0 ||
                    newVehicle.LoadCapacity > 0 ||
                    !string.IsNullOrEmpty(newVehicle.EngineType) || 
                    !string.IsNullOrEmpty(newVehicle.Category))
                {
                    throw new ArgumentException("Fields Mileage, Category, LoadCapacity must be empty for a Motorcycle.");
                } else if(string.IsNullOrEmpty(newVehicle.EngineType)){
                    throw new ArgumentException("EngineType field can't be empty for a Motorcycle.");
                }
        }

        private void ValidateSpecialMachinery(Vehicle newVehicle){
            if (newVehicle.Mileage > 0 ||
                    !string.IsNullOrEmpty(newVehicle.EngineType))
                {
                    throw new ArgumentException("Fields Mileage, EngineType must be empty for a SpecialMachinery.");
                } else if(string.IsNullOrEmpty(newVehicle.Category)){
                    throw new ArgumentException("Category field can't be empty for a SpecialMachinery.");
                } else if(newVehicle.LoadCapacity == 0 ){
                    throw new ArgumentException("LoadCapacity field can't equals 0 for a SpecialMachinery.");
                }
        }
    }
}