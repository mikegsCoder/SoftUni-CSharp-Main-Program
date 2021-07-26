using System;

namespace _15._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int polinatedFlowers = 0;
            int beeRow = -1;
            int beeCol = -1;
            
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            // Reading matrix:
            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string input = string.Empty;

            // Bee moves:
            while ((input = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                switch (input)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                if (!AreCoordinatesValid(beeRow, beeCol, matrix))
                {
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    polinatedFlowers++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    switch (input)
                    {
                        case "up":
                            beeRow--;
                            break;
                        case "down":
                            beeRow++;
                            break;
                        case "left":
                            beeCol--;
                            break;
                        case "right":
                            beeCol++;
                            break;
                    }

                    if (!AreCoordinatesValid(beeRow, beeCol, matrix))
                    {
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        polinatedFlowers++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';
            }

            if (!AreCoordinatesValid(beeRow, beeCol, matrix))
            {
                Console.WriteLine("The bee got lost!");
            }

            if (polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }

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
