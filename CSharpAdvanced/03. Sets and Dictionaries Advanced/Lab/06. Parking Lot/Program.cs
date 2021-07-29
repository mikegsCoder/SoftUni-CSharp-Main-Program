using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] currentInput = input.Split(", ");

                switch (currentInput[0])
                {
                    case "IN":
                        cars.Add(currentInput[1]);
                        break;
                    case "OUT":
                        cars.Remove(currentInput[1]);
                        break;
                }
            }

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
