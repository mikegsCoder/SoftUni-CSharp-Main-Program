using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] newCarInput = Console.ReadLine().Split();
                string newCarModel = newCarInput[0];
                int newCarEngineSpeed = int.Parse(newCarInput[1]);
                int newCarEnginePower = int.Parse(newCarInput[2]);
                int newCarCargoWeight = int.Parse(newCarInput[3]);
                string newCarCargoType = newCarInput[4];
                double newCarTyre1Pressure = double.Parse(newCarInput[5]);
                int newCarTyre1Age = int.Parse(newCarInput[6]);
                double newCarTyre2Pressure = double.Parse(newCarInput[7]);
                int newCarTyre2Age = int.Parse(newCarInput[8]);
                double newCarTyre3Pressure = double.Parse(newCarInput[9]);
                int newCarTyre3Age = int.Parse(newCarInput[10]);
                double newCarTyre4Pressure = double.Parse(newCarInput[11]);
                int newCarTyre4Age = int.Parse(newCarInput[12]);

                Car newCar = new Car(newCarModel, newCarEngineSpeed, newCarEnginePower, newCarCargoWeight,
                    newCarCargoType, newCarTyre1Pressure, newCarTyre1Age, newCarTyre2Pressure, newCarTyre2Age,
                    newCarTyre3Pressure, newCarTyre3Age, newCarTyre4Pressure, newCarTyre4Age);

                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            cars = cars.Where(c => c.Cargo.CargoType == command).ToList();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Tires.Any(t => t.TirePressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(c => c.Engine.EnginePower > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
