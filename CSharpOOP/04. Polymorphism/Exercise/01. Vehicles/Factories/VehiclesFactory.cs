using P01Vehicles.Models;
using P01Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01Vehicles.Factories
{
    public class VehiclesFactory
    {
        public VehiclesFactory()
        {

        }
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }
    }
}
