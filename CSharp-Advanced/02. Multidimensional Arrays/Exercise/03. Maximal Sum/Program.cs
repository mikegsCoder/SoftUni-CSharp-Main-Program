using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];
            int sum = 0;
            int startRowIndex = 0;
            int startColIndex = 0;


            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currentSum = 0;
 
                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            currentSum += matrix[k, l];
                        }
                    }

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startRowIndex = i;
                        startColIndex = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int i = startRowIndex; i < startRowIndex + 3; i++)
            {
                for (int j = startColIndex; j < startColIndex + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
