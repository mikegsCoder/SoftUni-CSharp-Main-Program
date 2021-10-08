using System;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            int collectedTokens = 0;
            int oponetTokens = 0;

            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            // reading matrix:
            for (int row = 0; row < n; row++)
            {
                string currInput = Console.ReadLine();

                char[] currRow = currInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = new char[currRow.Length];

                for (int col = 0; col < currRow.Length; col++)
                {
                    matrix[row][col] = currRow[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] commandArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int currRow = int.Parse(commandArgs[1]);
                int currCol = int.Parse(commandArgs[2]);

                if (!AreCoordinatesValid(currRow, currCol, matrix))
                {
                    continue;
                }

                switch (commandArgs[0])
                {
                    case "Find":
                        if (matrix[currRow][currCol] == 'T')
                        {
                            collectedTokens++;
                            matrix[currRow][currCol] = '-';
                        }
                        break;
                    case "Opponent":
                        string currDirection = commandArgs[3];

                        if (matrix[currRow][currCol] == 'T')
                        {
                            oponetTokens++;
                            matrix[currRow][currCol] = '-';
                        }

                        // first move:
                        Tuple<int, int> firstMove = Move(currRow, currCol, currDirection);

                        currRow = firstMove.Item1;
                        currCol = firstMove.Item2;

                        if (!AreCoordinatesValid(currRow, currCol, matrix))
                        {
                            continue;
                        }
                        if (matrix[currRow][currCol] == 'T')
                        {
                            oponetTokens++;
                            matrix[currRow][currCol] = '-';
                        }

                        // second move:
                        Tuple<int, int> secondMove = Move(currRow, currCol, currDirection);

                        currRow = secondMove.Item1;
                        currCol = secondMove.Item2;

                        if (!AreCoordinatesValid(currRow, currCol, matrix))
                        {
                            continue;
                        }
                        if (matrix[currRow][currCol] == 'T')
                        {
                            oponetTokens++;
                            matrix[currRow][currCol] = '-';
                        }

                        // thirth move:
                        Tuple<int, int> thirthMove = Move(currRow, currCol, currDirection);

                        currRow = thirthMove.Item1;
                        currCol = thirthMove.Item2;

                        if (!AreCoordinatesValid(currRow, currCol, matrix))
                        {
                            continue;
                        }
                        if (matrix[currRow][currCol] == 'T')
                        {
                            oponetTokens++;
                            matrix[currRow][currCol] = '-';
                        }
                        break;
                }
            }
            
            PrintMatrix(matrix);

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {oponetTokens}");
        }

        private static Tuple<int, int> Move(int currRow, int currCol, string currDirection)
        {
            switch (currDirection)
            {
                case "up":
                    currRow--;
                    break;
                case "down":
                    currRow++;
                    break;
                case "left":
                    currCol--;
                    break;
                case "right":
                    currCol++;
                    break;
            }

            return new Tuple<int, int>(currRow, currCol);
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreCoordinatesValid(int row, int col, char[][] matrix)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length);
        }
    }
}
