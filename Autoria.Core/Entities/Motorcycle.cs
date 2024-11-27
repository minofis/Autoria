namespace Autoria.Core.Entities
{
    public class Motorcycle : Vehicle
    {
        public string EngineType { get; set; } = string.Empty;

        public override Vehicle Create(Vehicle newVehicle)
        {
            var createdVehicle = base.Create(newVehicle);
            if (createdVehicle is Motorcycle motorcycleOutput && newVehicle is Motorcycle motorcycleInput)
            {
                motorcycleOutput.EngineType = motorcycleInput.EngineType;
            } else{
                throw new ArgumentException("Invalid Motorcycle Input");
            }
            return createdVehicle;
        }
    }
}