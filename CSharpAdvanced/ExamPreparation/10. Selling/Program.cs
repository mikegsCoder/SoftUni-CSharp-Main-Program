using System;

namespace _13._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 0;
            int sellerRow = -1;
            int sellerCol = -1;
            int pillarOneRow = -2;
            int pillarOneCol = -2;
            int pillarTwoRow = -3;
            int pillarTwoCol = -3;

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            // Reading matrix:
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        if (pillarOneRow < 0)
                        {
                            pillarOneRow = row;
                            pillarOneCol = col;
                        }
                        else if (pillarOneRow >= 0 && pillarTwoRow < 0)
                        {
                            pillarTwoRow = row;
                            pillarTwoCol = col;
                        }
                    }
                }
            }

            // Moving:
            while (true)
            {
                string moveCommand = Console.ReadLine();

                matrix[sellerRow, sellerCol] = '-';

                switch (moveCommand)
                {
                    case "up":
                        sellerRow--;
                        break;
                    case "down":
                        sellerRow++;
                        break;
                    case "left":
                        sellerCol--;
                        break;
                    case "right":
                        sellerCol++;
                        break;
                }

                if (!AreCoordinatesValid(sellerRow, sellerCol, matrix))
                {
                    break;
                }

                if (Char.IsDigit(matrix[sellerRow, sellerCol]))
                {
                    money += int.Parse(matrix[sellerRow, sellerCol].ToString());
                }

                if (matrix[sellerRow, sellerCol] == 'O')
                {
                    matrix[sellerRow, sellerCol] = '-';

                    if (sellerRow == pillarOneRow && sellerCol == pillarOneCol)
                    {
                        sellerRow = pillarTwoRow;
                        sellerCol = pillarTwoCol;
                    }
                    else
                    {
                        sellerRow = pillarOneRow;
                        sellerCol = pillarOneCol;
                    }
                }

                matrix[sellerRow, sellerCol] = 'S';

                if (money >= 50)
                {
                    break;
                }
            }

            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

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

        private static bool AreCoordinatesValid(int row, int col, char[,] matrix)
        {
            return (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1));
        }
    }
}
