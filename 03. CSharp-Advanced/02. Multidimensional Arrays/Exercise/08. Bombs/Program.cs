using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBomb = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentBombRow = currentBomb[0];
                int currentBombCol = currentBomb[1];

                BombExplosion(matrix, currentBombRow, currentBombCol);
            }

            int activeCells = 0;
            int sum = 0;

            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    activeCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BombExplosion(int[,] matrix, int row, int col)
        {
            if (CellIsValid(matrix, row, col))
            {
                int bombValue = matrix[row, col];

                matrix[row, col] = 0;

                if (CellIsValid(matrix, row-1, col-1))
                {
                    matrix[row - 1, col - 1] -= bombValue;
                }
                if (CellIsValid(matrix, row - 1, col))
                {
                    matrix[row - 1, col] -= bombValue;
                }
                if (CellIsValid(matrix, row - 1, col + 1))
                {
                    matrix[row - 1, col + 1] -= bombValue;
                }
                if (CellIsValid(matrix, row , col - 1))
                {
                    matrix[row , col - 1] -= bombValue;
                }
                if (CellIsValid(matrix, row , col + 1))
                {
                    matrix[row , col + 1] -= bombValue;
                }
                if (CellIsValid(matrix, row + 1, col - 1))
                {
                    matrix[row + 1, col - 1] -= bombValue;
                }
                if (CellIsValid(matrix, row + 1, col))
                {
                    matrix[row + 1, col] -= bombValue;
                }
                if (CellIsValid(matrix, row + 1, col + 1))
                {
                    matrix[row + 1, col + 1] -= bombValue;
                }
            }
        }

        private static bool CellIsValid(int[,] matrix, int row, int col)
        {
            int length = matrix.GetLength(0);
            return row >= 0 && row < length && col >= 0 && col < length && matrix[row, col] > 0;
        }
    }
}
