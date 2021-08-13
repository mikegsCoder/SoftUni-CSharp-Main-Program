using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CSharp_Fundamentals_Lists_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            SumAdjacentEqualNums(numbers);
        }

        static void SumAdjacentEqualNums(List<double> numbers)
        {
            int i = 0;
            while (i < numbers.Count-1)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
                i++;
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
