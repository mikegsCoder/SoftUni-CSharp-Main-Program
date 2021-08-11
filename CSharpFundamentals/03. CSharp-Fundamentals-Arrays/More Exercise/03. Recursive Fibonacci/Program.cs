using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if(n == 1)
            {
                Console.WriteLine(1);
            }

            if (n > 1)
            {
                int[] fibonacci = new int[n];
                fibonacci[0] = 1;
                fibonacci[1] = 1;

                for (int i = 2; i < n; i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }

                Console.WriteLine(fibonacci[n-1]);
            }
        }
    }
}
