using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            string[] engineProp = new string[4];

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    engineProp[j] = "n/a";
                }

                string[] newEngineStr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < newEngineStr.Length; k++)
                {
                    engineProp[k] = newEngineStr[k];
                }

                if (newEngineStr.Length == 3)
                {
                    if (Char.IsLetter(newEngineStr[2][0]))
                    {
                        engineProp[2] = "n/a";
                        engineProp[3] = newEngineStr[2];
                    }
                }

                Engine engine = new Engine(engineProp[0], engineProp[1], engineProp[2], engineProp[3]);
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            string[] carProp = new string[4];

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    carProp[j] = "n/a";
                }

                string[] newCarStr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < newCarStr.Length; k++)
                {
                    carProp[k] = newCarStr[k];
                }

                if (newCarStr.Length == 3)
                {
                    if (Char.IsLetter(newCarStr[2][0]) )
                    {
                        carProp[2] = "n/a";
                        carProp[3] = newCarStr[2];
                    }
                }

                Car car = new Car(carProp[0], carProp[1], carProp[2], carProp[3]);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Engine engine = engines.FirstOrDefault(e => e.Model == car.Engine);
                Console.WriteLine(CarPrinter(car,engine));
            }
        }
        public static string CarPrinter(Car car, Engine engine)
        {            
            string res = $"{car.Model}:" + Environment.NewLine;
            res += $"  {engine.Model}:" + Environment.NewLine;
            res += $"    Power: {engine.Power}" + Environment.NewLine;
            res += $"    Displacement: {engine.Displacement}" + Environment.NewLine;
            res += $"    Efficiency: {engine.Efficiency}" + Environment.NewLine;
            res += $"  Weight: {car.Weight}" + Environment.NewLine;
            res += $"  Color: {car.Color}";

            return res;
        }
    }
}
