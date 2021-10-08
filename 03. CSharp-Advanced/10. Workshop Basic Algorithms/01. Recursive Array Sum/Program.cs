using System;
using System.Linq;

namespace P01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            long sum = Sum(numbers, 0);

            Console.WriteLine(sum);
        }
        public static long Sum(int[] arr, int startIndex)
        {
            long sum = 0;

            if (startIndex == arr.Length-1)
            {
                return sum + arr[startIndex];
            }

            sum += arr[startIndex] + Sum(arr, startIndex + 1);

            return sum;
        }
    }
}
