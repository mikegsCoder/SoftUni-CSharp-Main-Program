using System;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double AvailableFuel = 65;
        private const double FuelConsumptionPERRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) 
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

            double hp = this.HorsePower;
            hp -= hp * 0.03;
            this.HorsePower = (int)Math.Round(hp, MidpointRounding.AwayFromZero);
        }
    }
}
