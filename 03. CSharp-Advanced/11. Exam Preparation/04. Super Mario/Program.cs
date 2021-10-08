using System;
using System.Linq;

namespace _04._Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioRow = -1;
            int marioCol = -1;
            int princesRow = -2;
            int princesCol = -2;

            bool isPrincessSaved = false;

            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            // Reading matrix
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }

                    if (matrix[row][col] == 'P')
                    {
                        princesRow = row;
                        princesCol = col;
                    }
                }
            }

            while (lives > 0)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int enemyRow = int.Parse(commandArgs[1]);
                int enemyCol = int.Parse(commandArgs[2]);
                string marioMoveDirection = commandArgs[0];

                lives = EnemyMove(lives, marioRow, marioCol, enemyRow, enemyCol, matrix);

                if (lives <= 0)
                {
                    break;
                }

                // Mario Moves:
                lives -= 1;
                matrix[marioRow][marioCol] = '-';

                // "W" (up), "S" (down), "A" (left), "D" (right)
                switch (marioMoveDirection)
                {
                    case "W":
                        if (marioRow > 0)
                        {
                            marioRow--;
                        }
                        break;
                    case "S":
                        if (marioRow < matrix.GetLength(0) - 1)
                        {
                            marioRow++;
                        }
                        break;
                    case "A":
                        if (marioCol > 0)
                        {
                            marioCol--;
                        }
                        break;
                    case "D":
                        if (marioCol < matrix[marioRow].Length - 1)
                        {
                            marioCol++;
                        }
                        break;
                }

                if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                    }
                    else
                    {
                        matrix[marioRow][marioCol] = 'M';
                    }
                }

                if (matrix[marioRow][marioCol] == '-')
                {
                    matrix[marioRow][marioCol] = 'M';
                }
                if (lives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
    
                if (marioRow == princesRow && marioCol == princesCol)
                {
                    matrix[marioRow][marioCol] = '-';
                    isPrincessSaved = true;
                    break;
                }
            }

            if (lives > 0 && isPrincessSaved)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            PrintMatrix(matrix);
        }

        private static int EnemyMove(int lives, int marioRow, int marioCol, int enemyRow, int enemyCol, char[][] matrix)
        {
            if (!AreCoordinatesValid(enemyRow, enemyCol, matrix))
            {
                return lives;
            }

            if (matrix[enemyRow][enemyCol] == '-')
            {
                matrix[enemyRow][enemyCol] = 'B';
            }

            return lives;
        }

        private static bool AreCoordinatesValid(int row, int col, char[][] matrix)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length);
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
