using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (input.Length == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                bool isSpecial = false;
                for (int i = 0; i < input.Length; i++)
                {
                    int leftSum = 0;
                    int rightSum = 0;

                    for (int j = 0; j < i; j++)
                    {
                        leftSum += input[j];
                    }

                    for (int k = i + 1; k < input.Length; k++)
                    {
                        rightSum += input[k];
                    }

                    if (leftSum == rightSum)
                    {
                        isSpecial = true;
                        Console.WriteLine(i);
                        break;
                    }
                }

                if (!isSpecial)
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
