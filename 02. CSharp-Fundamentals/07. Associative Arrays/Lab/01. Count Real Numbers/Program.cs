using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._CSharp_Fundamentals_Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var sortedDictionary = new SortedDictionary<double, int>();

            foreach (double number in numbers)
            {
                if (sortedDictionary.ContainsKey(number))
                {
                    sortedDictionary[number]++;
                }
                else
                {
                    sortedDictionary.Add(number, 1);
                }
            }

            foreach (var item in sortedDictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
