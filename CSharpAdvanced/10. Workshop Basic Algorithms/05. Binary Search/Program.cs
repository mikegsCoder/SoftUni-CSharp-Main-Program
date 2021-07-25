using System;
using System.Linq;

namespace P07._Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {           
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(array, number, 0, array.Length));
        }

        private static int BinarySearch(int[] array, int number, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int middle = (start + end) / 2;

            if (number < array[middle])
            {
                return BinarySearch(array, number, start, middle - 1);
            }
            else if (number > array[middle])
            {
                return BinarySearch(array, number, middle + 1 , end);
            }
            else
            {
                return middle;
            }
        }
    }
}
