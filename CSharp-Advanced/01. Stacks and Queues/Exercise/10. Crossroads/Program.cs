using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int carsPassed = 0;
            bool crash = false;
            string currentCar = string.Empty;
            int currentGreen = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else if (cars.Count > 0)
                {
                    currentGreen = greenLightDuration;

                    while (currentGreen > 0)
                    {
                        currentCar = cars.Dequeue();
                        currentGreen -= currentCar.Length;
                        carsPassed++;
                    }

                    if (freeWindowDuration < Math.Abs(currentGreen))
                    {
                        crash = true;
                        break;
                    }
                }
            }

            if (!crash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length - Math.Abs(currentGreen) + freeWindowDuration]}.");
            }
        }
    }
}
