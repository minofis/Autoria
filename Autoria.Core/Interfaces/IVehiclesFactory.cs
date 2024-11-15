using Autoria.Core.Entities;

namespace Autoria.Core.Interfaces
{
    public interface IVehiclesFactory
    {
        Vehicle CreateVehicle(Vehicle newVehicle);
    }
}