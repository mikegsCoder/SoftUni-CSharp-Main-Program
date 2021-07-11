using System;
using System.Collections.Generic;
using System.Text;
using P01Vehicles.Common;

namespace P01Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        private const double FUEL_CONSUMPTION_INCREMENT_FULL = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption =>
           base.FuelConsumption + FUEL_CONSUMPTION_INCREMENT_FULL;                
    }
}
