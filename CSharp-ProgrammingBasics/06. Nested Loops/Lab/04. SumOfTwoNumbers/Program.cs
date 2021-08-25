using System;

namespace _04.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int leftLimit = int.Parse(Console.ReadLine());
            int rightLimit = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationsCounter = 0;
            bool combinationFound = false;

            for (int i = leftLimit; i <= rightLimit; i++)
            {
                for (int j = leftLimit; j <= rightLimit; j++)
                {
                    combinationsCounter++;

                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinationsCounter} ({i} + {j} = {magicNum})");
                        combinationFound = true;
                        break;
                    }
                }

                if (combinationFound) break;
            }

            if (!combinationFound)
            {
                Console.WriteLine($"{combinationsCounter} combinations - neither equals {magicNum}");
            }
        }
    }
}
