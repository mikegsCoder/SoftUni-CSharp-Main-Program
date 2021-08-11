using System;

namespace _03._CSharp_Fundamentals_Arrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] peoples = new int[n];

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                peoples[i] = int.Parse(Console.ReadLine());
                sum += peoples[i];
            }

            Console.WriteLine(string.Join(" ",peoples));
            Console.WriteLine(sum);
        }
    }
}
