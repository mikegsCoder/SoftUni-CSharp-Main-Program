using System;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int spacePosition = 0;
            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                BigInteger leftNumber, rightNumber;
                string leftNumberString, rightNumberString;

                spacePosition = 0;

                int length = input.Length;

                for (int j = 0; j < length; j++)
                {
                    if ((int)input[j] == 32)
                    {
                        spacePosition = j;
                    }
                }

                leftNumberString = input.Substring(0, spacePosition);
                rightNumberString = input.Substring(spacePosition + 1, length - spacePosition - 1);

                leftNumber = BigInteger.Parse(leftNumberString);
                rightNumber = BigInteger.Parse(rightNumberString);
                                
                int sum = 0;

                if (leftNumber >= rightNumber)
                {
                    for (int l = 0; l < leftNumberString.Length; l++)
                    {
                        if ((int)leftNumberString[l] >= 48 && (int)leftNumberString[l] <= 57)
                        {
                            sum += (int)(Char.GetNumericValue(leftNumberString[l]));
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < rightNumberString.Length; m++)
                    {
                        if ((int)rightNumberString[m] >= 48 && (int)rightNumberString[m] <= 57)
                        {
                            sum += (int)(Char.GetNumericValue(rightNumberString[m]));
                        }
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}
