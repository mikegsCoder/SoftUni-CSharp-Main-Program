using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .ToArray();

            numbers = Select(numbers, number => number * 1.2m);

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }

        static decimal[] Select(decimal[] array, Func<decimal, decimal> transformer)
        {
            decimal[] newArray = new decimal[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = transformer(array[i]);
            }

            return newArray;
        }
    }
}
