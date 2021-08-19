using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, int>> flowers = new List<Tuple<int, int>>(); 

            int[] matrixArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int n = matrixArgs[0];
            int m = matrixArgs[1];

            int[,] matrix = new int[n, m];

            // Fill matrix with 0:
            for (int row = 0; row < n; row++)
            {                
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] currentFlower = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = currentFlower[0];
                int currentCol = currentFlower[1];

                if (!AreCoordinatesValid(currentCol, currentCol, matrix))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                flowers.Add(new Tuple<int, int>(currentCol, currentCol));
            }

            foreach (var flower in flowers)
            {
                Bloom(flower, matrix);
            }

            PrintMatrix(matrix);
        }
        private static bool AreCoordinatesValid(int row, int col, int[,] matrix)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }

        private static void Bloom(Tuple<int, int> flower, int[,] matrix) 
        {
            int row = flower.Item1;
            int col = flower.Item2;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] += 1;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row)
                {
                    continue;
                }
                matrix[i, col] += 1;
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
