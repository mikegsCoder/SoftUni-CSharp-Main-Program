using System;

namespace P02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        public static long Factorial(int n)
        {
            long factorial = 1;
            if (n == 1)
            {
                return factorial;
            }

            factorial = n * Factorial(n - 1);

            return factorial;
        }
    }
}
