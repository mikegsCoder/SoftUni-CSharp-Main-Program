using System;

namespace _01._Encrypt_Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sum = new int[n];

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                int length = input.Length;
                char[] currentInput = new char[length];
                int currentSum = 0;

                for (int j = 0; j < length; j++)
                {
                    currentInput[j] = input[j];
                    if (currentInput[j] == 'A' ||
                        currentInput[j] == 'E' ||
                        currentInput[j] == 'I' ||
                        currentInput[j] == 'O' ||
                        currentInput[j] == 'U' ||
                        currentInput[j] == 'a' ||
                        currentInput[j] == 'e' ||
                        currentInput[j] == 'i' ||
                        currentInput[j] == 'o' ||
                        currentInput[j] == 'u' )
                    {
                        currentSum += (int)currentInput[j] * length;
                    }
                    else
                    {
                        currentSum += (int)currentInput[j] / length;
                    }
                }
                
                sum[i-1] = currentSum;
            }

            Array.Sort(sum);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(sum[i]);
            }
        }
    }
}
