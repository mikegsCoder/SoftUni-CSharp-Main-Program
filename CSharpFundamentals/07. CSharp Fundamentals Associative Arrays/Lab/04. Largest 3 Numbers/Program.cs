using System;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sortedNums = numbers.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < Math.Min(3, sortedNums.Length); i++)
            {
                Console.Write($"{sortedNums[i]} ");
            }
        }
    }
}
