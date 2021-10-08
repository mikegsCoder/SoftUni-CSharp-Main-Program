using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minNumber = numbers =>
            {
                int minNum = int.MaxValue;
                foreach (int num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };

            List<int> numbers = Console.ReadLine().Split().Select(num => int.Parse(num)).ToList();

            Console.WriteLine(minNumber(numbers));
        }
    }
}
