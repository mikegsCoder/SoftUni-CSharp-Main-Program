namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double AvailableFuel = 80;
        private const double FuelConsumptionPERRace = 10;

        public SuperCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, AvailableFuel, FuelConsumptionPERRace)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;

            if (this.FuelAvailable < 0)
            {
                this.FuelAvailable = 0;
            }
        }
    }
}
