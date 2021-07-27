using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> people = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid" && people.Count > 0)
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(input);
                }
            }

            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}
