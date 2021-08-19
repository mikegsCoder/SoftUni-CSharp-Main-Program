using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            RemoveNegatives(numbers);
        }

        static void RemoveNegatives(List<int> numbers)
        {
            int i = 0;
            while (i < numbers.Count)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i -= 1;
                }

                i++;
            }

            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ",numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
