using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            int carNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < carNumber; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (!cars.ContainsKey(currentCar[0]))
                {
                    cars.Add(currentCar[0], new List<int>());
                    cars[currentCar[0]].Add(int.Parse(currentCar[1]));
                    cars[currentCar[0]].Add(int.Parse(currentCar[2]));
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] currentCommand = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string car = currentCommand[1];

                switch (currentCommand[0])
                {
                    case "Drive":
                        int distance = int.Parse(currentCommand[2]);
                        int fuelToDrive = int.Parse(currentCommand[3]);
                        if (cars.ContainsKey(car))
                        {
                            if (cars[car][1] >= fuelToDrive)
                            {
                                cars[car][0] += distance;
                                cars[car][1] -= fuelToDrive;
                                Console.WriteLine($"{car} driven for {distance} kilometers. {fuelToDrive} liters of fuel consumed.");

                                if (cars[car][0] >= 100000)
                                {
                                    cars.Remove(car);
                                    Console.WriteLine($"Time to sell the {car}!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                        }
                        break;
                    case "Refuel":
                        int fuelToAdd = int.Parse(currentCommand[2]);
                        if (cars.ContainsKey(car))
                        {
                            if (cars[car][1] + fuelToAdd > 75)
                            {
                                fuelToAdd = 75 - cars[car][1];
                            }

                            cars[car][1] += fuelToAdd;
                            Console.WriteLine($"{car} refueled with {fuelToAdd} liters");
                        }
                        break;
                    case "Revert":
                        bool almostNew = false;
                        int kilometers = int.Parse(currentCommand[2]);

                        if (cars.ContainsKey(car))
                        {
                            if (cars[car][0] - kilometers < 10000)
                            {
                                kilometers = cars[car][0] - 10000;
                                almostNew = true;
                            }
                            cars[car][0] -= kilometers;
                            if (!almostNew)
                            {
                                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                            }
                        }
                        break;
                }
            }
                        
            foreach (var car in cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
