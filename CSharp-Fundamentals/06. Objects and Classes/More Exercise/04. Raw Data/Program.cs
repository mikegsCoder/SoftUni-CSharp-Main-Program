using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = currentCar[0];
                int speed = int.Parse(currentCar[1]);
                int power = int.Parse(currentCar[2]);
                int weight = int.Parse(currentCar[3]);
                string type = currentCar[4];

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                Car car = new Car(model, engine, cargo);
                cars.Add(car);
            }

            string cargoFilterType = Console.ReadLine();

            foreach (var car in cars)
            {
                if (cargoFilterType == "fragile")
                {
                    if (car.Cargo.CargoType == "fragile" && car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                else if (cargoFilterType == "flamable")
                {
                    if(car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
    public class Car
    {

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }
    }
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
    }
    public class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }
    }
}
