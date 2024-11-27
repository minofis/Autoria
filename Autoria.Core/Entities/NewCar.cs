namespace Autoria.Core.Entities
{
    public class NewCar : Vehicle
    {
        public override Vehicle Create(Vehicle newVehicle)
        {
            return base.Create(newVehicle);
        }
    }
}