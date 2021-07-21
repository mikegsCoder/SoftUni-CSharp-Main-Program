using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInput = Console.ReadLine().Split();
                string carModel = carInput[0];
                double carFuel = double.Parse(carInput[1]);
                double carConsumption = double.Parse(carInput[2]);

                Car currentCar = new Car();
                currentCar.Model = carModel;
                currentCar.FuelAmount = carFuel;
                currentCar.FuelConsumptionPerKilometer = carConsumption;

                cars.Add(currentCar);
            }
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currentCommand = input.Split();
                string carModel = currentCommand[1];
                int distance = int.Parse(currentCommand[2]);
                                
                foreach (var car in cars.Where(c => c.Model == carModel))
                {
                   car.Drive(distance);                    
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
