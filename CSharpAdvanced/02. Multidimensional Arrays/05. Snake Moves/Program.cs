using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[,] island = new char[rows, cols];
            string snake = Console.ReadLine();

            int isleLength = rows * cols;
            int row = 0;
            int col = 0;
            int snakeIndex = 0;
            string direction = "right";

            for (int i = 0; i < isleLength; i++)
            {
                island[row, col] = snake[snakeIndex];
                
                snakeIndex++;
                if (snakeIndex == snake.Length)
                {
                    snakeIndex = 0;
                }
                if (direction == "right" && col <= cols - 1)
                {
                    col++;
                }
                if (direction == "right" && col > cols - 1 && row < rows - 1)
                {
                    row++;                    
                    direction = "left";
                }
                if (direction == "left" && col >= 0)
                {
                    col--;
                }
                if (direction == "left" && col < 0 && row < rows - 1)
                {
                    row++;
                    col++;
                    direction = "right";
                } 
            }
            PrintMatrix(island);
        }
        static void PrintMatrix(char[,] island)
        {
            for (int row = 0; row < island.GetLength(0); row++)
            {
                for (int col = 0; col < island.GetLength(1); col++)
                {
                    Console.Write(island[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
