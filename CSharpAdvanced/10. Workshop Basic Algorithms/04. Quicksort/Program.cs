using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {      
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            QuickSort(numbers, 0, numbers.Count - 1);

            Console.WriteLine(String.Join(' ', numbers));
        }

        public static void QuickSort(List<int> numbers, int left, int right)
        {
            if (left < right)
            {
                var partitionIndex = Partition(numbers, left, right);
                QuickSort(numbers, left, partitionIndex);
                QuickSort(numbers, partitionIndex + 1, right);
            }
        }

        static int Partition(List<int> numbers, int left, int right)
        {
            int pivot = numbers[(left + right) / 2];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;
                }
                while (numbers[i] < pivot);
                do
                {
                    j--;
                }
                while (numbers[j] > pivot);

                if (i >= j)
                {
                    return j;
                }

                var temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }
    }
}
