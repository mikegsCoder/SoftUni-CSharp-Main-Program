using System;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            if (n > input.Length)
            {
                n = n - input.Length;
            }

            string[] output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                int j = i + n;
                if (j > input.Length-1)
                {
                    j = i + n - input.Length;
                }

                output[i] = input[j];
            }

            Console.WriteLine(string.Join(" ",output));
        }
    }
}
