using System;
using System.Linq;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(1);
            }

            if (n == 2)
            {
                Console.WriteLine(1);
                Console.WriteLine("1 1");
            }

            if (n > 2)
            {
                Console.WriteLine(1);
                Console.WriteLine("1 1");
                int[] previousRow = { 1, 1 };

                for (int i = 3; i <= n; i++)
                {
                    int[] currentRow = new int[i];
                    currentRow[0] = 1;
                    currentRow[i-1] = 1;

                    for (int j = 1; j <= i - 2; j++)
                    {
                        currentRow[j] = previousRow[j - 1] + previousRow[j];
                    }

                    Console.WriteLine(string.Join(' ', currentRow));
                    previousRow = currentRow.ToArray();
                }
            }
        }
    }
}
