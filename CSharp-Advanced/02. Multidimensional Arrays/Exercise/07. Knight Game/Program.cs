using System;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    board[row, col] = rowData[col];
                }
            }

            int removedKnightsCount = 0;

            while (true)
            {
                int maxAttakedKnightsCount = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char symbol = board[row, col];
                        if (symbol != 'K')
                        {
                            continue;
                        }

                        int count = GetCountOfAttakedKnights(board, row, col);

                        if (count > maxAttakedKnightsCount)
                        {
                            maxAttakedKnightsCount = count;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttakedKnightsCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                removedKnightsCount++;
            }

            Console.WriteLine(removedKnightsCount);
        }

        private static int GetCountOfAttakedKnights(char[,] board, int row, int col)
        {
            int count = 0;

            if (ContainsKnight(board, row - 2, col - 1))
            {
                count++;
            }
            if (ContainsKnight(board, row - 2, col + 1))
            {
                count++;
            }
            if (ContainsKnight(board, row - 1, col - 2))
            {
                count++;
            }
            if (ContainsKnight(board, row - 1, col + 2))
            {
                count++;
            }
            if (ContainsKnight(board, row + 1, col - 2))
            {
                count++;
            }
            if (ContainsKnight(board, row + 1, col + 2))
            {
                count++;
            }
            if (ContainsKnight(board, row + 2, col - 1))
            {
                count++;
            }
            if (ContainsKnight(board, row + 2, col + 1))
            {
                count++;
            }

            return count;
        }

        private static bool ContainsKnight(char[,] board, int row, int col)
        {
            if (!IsValidCell(row,col,board.GetLength(0)))
            {
                return false;
            }

            return board[row, col] == 'K';
        }

        private static bool IsValidCell(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
