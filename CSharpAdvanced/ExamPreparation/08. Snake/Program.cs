using System;

namespace _09._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int snakeRow = -1;
            int snakeCol = -1;
            int burrowOneRow = -2;
            int burrowOneCol = -2;
            int burrowTwoRow = -3;
            int burrowTwoCol = -3;
            int foodEaten = 0;

            bool isSnakeInTheMatrix = true;

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            // Reading matrix :
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (burrowOneRow < 0)
                        {
                            burrowOneRow = row;
                            burrowOneCol = col;
                        }
                        else
                        {
                            burrowTwoRow = row;
                            burrowTwoCol = col;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();


                matrix[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;

                    if (snakeRow < 0)
                    {
                        isSnakeInTheMatrix = false;
                        break;
                    }
                }
                else if (command == "down")
                {
                    snakeRow++;

                    if (snakeRow == matrix.GetLength(0))
                    {
                        isSnakeInTheMatrix = false;
                        break;
                    }
                }
                else if (command == "left")
                {
                    snakeCol--;

                    if (snakeCol < 0)
                    {
                        isSnakeInTheMatrix = false;
                        break;
                    }
                }
                else if (command == "right")
                {
                    snakeCol++;

                    if (snakeCol == matrix.GetLength(1))
                    {
                        isSnakeInTheMatrix = false;
                        break;
                    }
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    if (snakeRow == burrowOneRow && snakeCol == burrowOneCol)
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = burrowTwoRow;
                        snakeCol = burrowTwoCol;
                    }
                    else if (snakeRow == burrowTwoRow && snakeCol == burrowTwoCol)
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = burrowOneRow;
                        snakeCol = burrowOneCol;
                    }
                }

                matrix[snakeRow, snakeCol] = 'S';

                if (foodEaten == 10)
                {
                    break;
                }

            }

            if (foodEaten == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            PrintMatrix(matrix);            
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
