using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => 
            base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT;
    }
}
