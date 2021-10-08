using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading the array range
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            // reading integer numbers and filling the array
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // printing the numbers in reverse order
            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(numbers[i]+" ");
            }
        }
    }
}
