using System;
using System.Collections.Generic;
using System.Text;
using P01Vehicles.Models;
using P01Vehicles.Interfaces;
using System.Linq;
using P01Vehicles.Factories;

namespace P01Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehiclesFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehiclesFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double argument = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, argument);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, argument);
                        }
                    }
                    else if (cmdType == "DriveEmpty" && vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.DriveEmpty(argument));
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, argument);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, argument);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle currentVahicle = this.vehicleFactory
                .CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return currentVahicle;
        }
    }
}
