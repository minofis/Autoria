namespace Autoria.Core.Entities
{
    public class SpecialMachinery : Vehicle
    {
        public string Category { get; set; } = string.Empty;
        public int LoadCapacity { get; set; }

        public override Vehicle Create(Vehicle newVehicle)
        {
            var createdVehicle = base.Create(newVehicle);
            if (createdVehicle is SpecialMachinery specialMachineryOutput && newVehicle is SpecialMachinery specialMachineryInput)
            {
                specialMachineryOutput.Category = specialMachineryInput.Category;
                specialMachineryOutput.LoadCapacity = specialMachineryInput.LoadCapacity;
            } else{
                throw new ArgumentException("Invalid SpecialMachinery Input");
            }
            return createdVehicle;
        }
    }
}