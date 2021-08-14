using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string carModel = carInput[0];
                double fuelAmount = double.Parse(carInput[1]);
                double fuelConsumption = double.Parse(carInput[2]);
                Car car = new Car(carModel, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] driveCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string carModel = driveCommand[1];
                double amountOfKm = double.Parse(driveCommand[2]);

                foreach (var car in cars)
                {
                    if (car.CarName == carModel)
                    {
                        double distance = car.FuelAmount / car.FuelConsumption;

                        if (distance >= amountOfKm)
                        {
                            car.FuelAmount -= amountOfKm * car.FuelConsumption;
                            car.DistanceTraveled += amountOfKm;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
    public class Car
    {
        public string CarName { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double DistanceTraveled { get; set; }

        public Car(string carName, double fuelAmount, double fuelConsumption)
        {
            this.CarName = carName;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public override string ToString()
        {
            string text = $"{CarName} {FuelAmount:f2} {DistanceTraveled}";
            return text;
        }
    }
}
