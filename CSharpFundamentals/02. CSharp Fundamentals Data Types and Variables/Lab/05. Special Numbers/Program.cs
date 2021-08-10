using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string digit = i.ToString();
                int length = digit.Length;
                int sum = 0;

                for (int j = 0; j < length; j++)
                {
                    sum += (int)Char.GetNumericValue(digit[j]);
                }

                if (sum == 5 || sum ==7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
