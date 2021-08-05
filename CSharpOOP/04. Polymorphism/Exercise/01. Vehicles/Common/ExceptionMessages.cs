using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Common
{
    public static class ExceptionMessages
    {
        public const string NotEnoughFuel = "{0} needs refueling";
        public const string NegativeFuel = "Fuel must be a positive number";
        public const string InvalidVehicleType = "Invalid vehicle type!";
        public const string InvalidFuelQuantity = "Cannot fit {0} fuel in the tank";
    }
}
