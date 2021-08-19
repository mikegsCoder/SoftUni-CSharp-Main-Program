using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
