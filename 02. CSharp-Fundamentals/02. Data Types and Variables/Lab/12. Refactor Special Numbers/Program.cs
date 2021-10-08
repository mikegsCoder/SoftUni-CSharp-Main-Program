using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            int current = 0;

            for (int i = 1; i <= n; i++)
            {
                sum = 0;
                current = i;

                while (current > 0)
                {
                    sum += current % 10;
                    current = current / 10;
                }

                bool isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }

        }
    }
}
