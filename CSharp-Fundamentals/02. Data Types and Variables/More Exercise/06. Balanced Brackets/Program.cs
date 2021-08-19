using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int openedBracketsCounter = 0;
            int closedBracketsCounter = 0;
            bool isBalanced = true;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                if (input.Length == 1)
                {                    
                    if ((int)input[0] == 40)
                    {
                        openedBracketsCounter += 1;
                    }

                    if ((int)input[0] == 41)
                    {
                        closedBracketsCounter += 1;
                    }

                    if (openedBracketsCounter - closedBracketsCounter > 1 || openedBracketsCounter - closedBracketsCounter < 0)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (n <= 1 || openedBracketsCounter != closedBracketsCounter)
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
