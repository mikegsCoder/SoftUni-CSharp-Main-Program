using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int minerRow = -1;
            int minerCol = -1;
            int eRow = -1;
            int eCol = -1;
            int coalsOnField = 0;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowData[col];
                    if (field[row,col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (field[row,col] == 'e')
                    {
                        eRow = row;
                        eCol = col;
                    }
                    if (field[row, col] == 'c')
                    {
                        coalsOnField++;
                    }
                }
            }

            bool isEnd = false;
            bool noCoals = false;
            int coalsCollected = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                int minerNewRow = minerRow;
                int minerNewCol = minerCol;

                if (commands[i] == "up")
                {
                    minerNewRow--;
                }
                if (commands[i] == "down")
                {
                    minerNewRow++;
                }
                if (commands[i] == "left")
                {
                    minerNewCol--;
                }
                if (commands[i] == "right")
                {
                    minerNewCol++;
                }

                if (IsCellValid(field, minerNewRow, minerNewCol))
                {
                    if (field[minerNewRow,minerNewCol] == 'e')
                    {
                        minerRow = minerNewRow;
                        minerCol = minerNewCol;
                        isEnd = true;
                        break;
                    }
                    else if (field[minerNewRow, minerNewCol] == 'c')
                    {
                        field[minerRow, minerCol] = '*';
                        field[minerNewRow, minerNewCol] = 's';
                        minerRow = minerNewRow;
                        minerCol = minerNewCol;
                        coalsCollected++;
                        if (coalsCollected == coalsOnField)
                        {
                            noCoals = true;
                            break;
                        }
                    }
                    else
                    {
                        field[minerRow, minerCol] = '*';
                        field[minerNewRow, minerNewCol] = 's';
                        minerRow = minerNewRow;
                        minerCol = minerNewCol;
                    }
                }
            }

            if (isEnd)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (noCoals)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{coalsOnField - coalsCollected} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsCellValid(char[,] field, int row, int col)
        {
            int length = field.GetLength(0);

            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
