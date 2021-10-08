using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            TribonacciSequence(num);
        }

        static void TribonacciSequence(int num)
        {
            if (num == 1)
            {
                Console.WriteLine("1");
            }

            if (num == 2)
            {
                Console.WriteLine("1 1");
            }

            if (num == 3)
            {
                Console.WriteLine("1 1 2");
            }

            if (num > 3)
            {
                int[] tribonacci = new int[num];
                tribonacci[0] = 1;
                tribonacci[1] = 1;
                tribonacci[2] = 2;

                for (int i = 3; i < num; i++)
                {
                    tribonacci[i] = tribonacci[i - 3] + tribonacci[i - 2] + tribonacci[i - 1];
                }

                Console.WriteLine(string.Join(' ',tribonacci));
            }

        }
    }
}
