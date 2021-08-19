using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._CSharp_Advanced_Sets_and_Dictionaries_Advanced_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> times = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!times.ContainsKey(numbers[i]))
                {
                    times.Add(numbers[i], 1);
                }
                else
                {
                    times[numbers[i]] += 1;
                }
            }

            foreach (var number in times)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
