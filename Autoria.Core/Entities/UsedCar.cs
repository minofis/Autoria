namespace Autoria.Core.Entities
{
    public class UsedCar : Vehicle
    {
        public int Mileage { get; set; }

        public override Vehicle Create(Vehicle newVehicle)
        {
            var createdVehicle = base.Create(newVehicle);
            if (createdVehicle is UsedCar usedCarOutput && newVehicle is UsedCar usedCarInput)
            {
                usedCarOutput.Mileage = usedCarInput.Mileage;
            } else{
                throw new ArgumentException("Invalid UsedCar Input");
            }
            return createdVehicle;
        }
    }
}