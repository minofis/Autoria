using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces.Factories
{
    public interface IVehiclesFactory
    {
        Vehicle CreateVehicle(Vehicle newVehicle);
    }
}