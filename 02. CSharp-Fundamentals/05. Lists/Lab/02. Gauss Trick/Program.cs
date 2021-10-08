using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            GaussTrick(numbers);
        }

        static void GaussTrick(List<double> numbers)
        {
            List<double> result = new List<double>();

            if (numbers.Count % 2 == 0)
            {
                for (int i = 0; i < (numbers.Count/2); i++)
                {
                    result.Add(numbers[i] + numbers[numbers.Count -1 - i]);                    
                }
            }
            else
            {
                for (int i = 0; i < (numbers.Count -1) / 2; i++)
                {
                    result.Add(numbers[i] + numbers[numbers.Count -1 - i]);
                }

                result.Add(numbers[(numbers.Count - 1)/2]);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
