using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPassedOnGreen = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int count = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsPassedOnGreen; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue() + " passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
