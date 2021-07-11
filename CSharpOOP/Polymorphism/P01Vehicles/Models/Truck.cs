using System;
using System.Collections.Generic;
using System.Text;
using P01Vehicles.Common;

namespace P01Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double REFUEL_SUCC_COEFF = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => 
            base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT;
        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }
            else if (amount > (this.TankCapacity - this.FuelQuantity))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFuelQuantity, amount));
            }

            this.FuelQuantity += amount * REFUEL_SUCC_COEFF;
        }
    }
}
