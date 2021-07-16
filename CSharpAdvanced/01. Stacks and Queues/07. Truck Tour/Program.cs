using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 0;
            int startIndexWithTour = 0;
            int currentIndex = 0;
            int fuelInTruck = 0;
            bool haveATour = false;

            Queue<int> fuel = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                fuel.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }

            while (!haveATour) 
            {
                if (fuel.Peek() + fuelInTruck >= distance.Peek())
                {
                    if (counter == 0)
                    {
                        startIndexWithTour = currentIndex;
                    }

                    counter++;
                    fuelInTruck += fuel.Peek();
                    fuelInTruck -= distance.Peek();

                    if (counter == n)
                    {
                        haveATour = true;
                        break;
                    }

                    fuel.Enqueue(fuel.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                }                
                else
                {
                    counter = 0;
                    fuelInTruck = 0;
                    fuel.Enqueue(fuel.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                }
                
                currentIndex++;
            }

            Console.WriteLine(startIndexWithTour);
        }
    }
}
