using Autoria.Core.Entities;
using Autoria.Core.Interfaces.Factories;

namespace Autoria.Core.Factories
{
    public class VehiclesFactory /*: IVehiclesFactory*/
    {
        /*
        public Vehicle CreateVehicle(Vehicle newVehicle)
        {
            if(newVehicle == null)
            {
                throw new ArgumentException("Vehicle can't be null", nameof(newVehicle));
            }

            Vehicle vehicle;

            switch (newVehicle)
            {
                case "NewCar":
                ValidateNewCar(newVehicle);

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

        private static void ValidateNewCar(Vehicle newVehicle)
        {
            if (newVehicle.Mileage > 0) throw new ArgumentException("Field Mileage must be 0 for a NewCar");
            if (newVehicle.LoadCapacity > 0) throw new ArgumentException("Field LoadCapacity must be 0 for a NewCar");
            if (!string.IsNullOrEmpty(newVehicle.EngineType)) throw new ArgumentException("Field EngineType must be empty for a NewCar");
            if (!string.IsNullOrEmpty(newVehicle.Category)) throw new ArgumentException("Field Category must be empty for a NewCar");
        }
        private static void ValidateUsedCar(Vehicle newVehicle)
        {
            if (newVehicle.LoadCapacity > 0) throw new ArgumentException("Field LoadCapacity must be 0 for a UsedCar");
            if (!string.IsNullOrEmpty(newVehicle.EngineType)) throw new ArgumentException("Field EngineType must be empty for a UsedCar");
            if (!string.IsNullOrEmpty(newVehicle.Category)) throw new ArgumentException("Field Category must be empty for a UsedCar");
            if(newVehicle.Mileage == 0) throw new ArgumentException("Mileage field is required for UsedCar");
        }

        private static void ValidateMotorcycle(Vehicle newVehicle)
        {
            if (newVehicle.LoadCapacity > 0) throw new ArgumentException("Field LoadCapacity must be 0 for a Motorcycle");
            if (!string.IsNullOrEmpty(newVehicle.Category)) throw new ArgumentException("Field Category must be empty for a Motorcycle");
            if (newVehicle.Mileage > 0) throw new ArgumentException("Field Mileage must be 0 for a Motorcycle");
            if(string.IsNullOrEmpty(newVehicle.EngineType)) throw new ArgumentException("EngineType field is required for Motorcycle");
        }

        private static void ValidateSpecialMachinery(Vehicle newVehicle)
        {
            if (newVehicle.Mileage > 0) throw new ArgumentException("Field Mileage must be 0 for a SpecialMachinery");
            if (!string.IsNullOrEmpty(newVehicle.EngineType)) throw new ArgumentException("Field EngineType must be empty for a SpecialMachinery");
            if(string.IsNullOrEmpty(newVehicle.Category)) throw new ArgumentException("Category field is required for SpecialMachinery.");
            if(newVehicle.LoadCapacity == 0 ) throw new ArgumentException("LoadCapacity field is required for SpecialMachinery");
        }
        */
    }
}