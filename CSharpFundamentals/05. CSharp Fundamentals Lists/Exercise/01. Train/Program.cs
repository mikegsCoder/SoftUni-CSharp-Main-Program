using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CSharp_Fundamentals_Lists_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            Train(wagons, capacity);
        }

        static void Train(List<int> wagons, int capacity)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand[0] == "Add")
                {
                    wagons.Add(int.Parse(currentCommand[1].ToString()));
                }
                else
                {
                    int newPasangers = int.Parse(currentCommand[0].ToString());
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + newPasangers) <= capacity)
                        {
                            wagons[i] += newPasangers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
