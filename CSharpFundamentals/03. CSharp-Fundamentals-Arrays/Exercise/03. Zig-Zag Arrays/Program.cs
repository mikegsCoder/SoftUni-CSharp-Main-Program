using System;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] input = new string[2];

            string[] arr1 = new string[n];
            string[] arr2 = new string[n];

            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (i % 2 != 0)
                {
                    arr1[i - 1] = input[0];
                    arr2[i - 1] = input[1];
                }
                else
                {
                    arr1[i - 1] = input[1];
                    arr2[i - 1] = input[0];
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
