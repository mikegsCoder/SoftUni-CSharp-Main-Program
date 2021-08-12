using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = input.Length;
            int[] firstRow = new int[length / 2];
            int[] secondRow = new int[length / 2];

            for (int i = 0; i < length / 4; i++)
            {
                firstRow[i] = input[(length / 4) - i - 1];
                firstRow[(length / 2) - i - 1] = input[(length / 4) * 3 + i];
            }

            for (int i = 0; i < length / 2; i++)
            {
                secondRow[i] = input[(length / 4) + i];
            }

            int[] sum = new int[length / 2];
            for (int i = 0; i < length / 2; i++)
            {
                sum[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(' ', sum));
        }
    }
}
