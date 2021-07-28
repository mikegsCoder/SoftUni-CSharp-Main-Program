using System;
using System.Linq;

namespace _02._CSharp_Advanced_Multidimensional_Arrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
