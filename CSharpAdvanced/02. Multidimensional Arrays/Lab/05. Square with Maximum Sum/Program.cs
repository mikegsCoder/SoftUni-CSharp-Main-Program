using System;
using System.Linq;

namespace _05._Square_with_Maximum_Sum
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

            int sum = 0;
            int startIndexRow = -1;
            int startIndexCol = -1;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startIndexRow = row;
                        startIndexCol = col;
                    }
                }
            }

            Console.WriteLine(matrix[startIndexRow,startIndexCol] + " " + matrix[startIndexRow, startIndexCol+1]);
            Console.WriteLine(matrix[startIndexRow+1,startIndexCol] + " " + matrix[startIndexRow+1, startIndexCol+1]);
            Console.WriteLine(sum);
        }
    }
}
