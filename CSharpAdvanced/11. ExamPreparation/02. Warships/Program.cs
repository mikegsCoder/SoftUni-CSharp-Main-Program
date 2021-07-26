using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int shipsCount = 0;
            string attackArgument;
            
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            Queue<string> attackArgs = new Queue<string>(Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries));


            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row, col] = currentRow[col];
                    if (currentRow[col] == '<' || currentRow[col] == '>')
                    {
                        shipsCount++;
                    }
                }
            }

            int playerOneShips = CountOfPlayerShips('<', field);
            int playerTwoShips = CountOfPlayerShips('>', field);
                        
            // game starts !!!
            while (playerOneShips > 0 && playerTwoShips > 0)
            {                
                if (attackArgs.Count == 0)
                {
                    break;
                }

                attackArgument = attackArgs.Dequeue();
                Attack(attackArgument, field);
                               
                if ((playerTwoShips = CountOfPlayerShips('>', field)) == 0)
                {
                    break;
                }

                if (attackArgs.Count == 0)
                {
                    break;
                }

                attackArgument = attackArgs.Dequeue();
                Attack(attackArgument, field);

                if ((playerOneShips = CountOfPlayerShips('<', field)) == 0)
                {
                    break;
                }
            }

            playerOneShips = CountOfPlayerShips('<', field);
            playerTwoShips = CountOfPlayerShips('>', field);
                       
            if (playerTwoShips == 0 && playerOneShips > 0)
            {
                Console.WriteLine
                    ($"Player One has won the game! {shipsCount - playerOneShips} ships have been sunk in the battle.");
            }
            else if (playerOneShips == 0 && playerTwoShips > 0)
            {
                Console.WriteLine
                    ($"Player Two has won the game! {shipsCount - playerTwoShips} ships have been sunk in the battle.");
            }            
            else if(attackArgs.Count == 0)
            {
                Console.WriteLine
                    ($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }           
        }

        private static int CountOfPlayerShips(char v, char[,] field)
        {
            int ships = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == v)
                    {
                        ships++;
                    }
                }
            }

            return ships;
        }

        private static void Attack(string args, char[,] field)
        {
            int row = int.Parse(args.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
            int col = int.Parse(args.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

            if (!CoordinatesAreValid(row, col, field.GetLength(0)))
            {
                return;
            }

            if (field[row, col] == '>')
            {
                field[row, col] = 'X';
            }
            if (field[row, col] == '<')
            {
                field[row, col] = 'X';
            }
            else if (field[row, col] == '#')
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (CoordinatesAreValid(i, j, field.GetLength(0)))
                        {
                            field[i, j] = 'X';
                        }
                    }
                }
            }

            return;
        }

        private static bool CoordinatesAreValid(int row, int col, int length)
        {
            return (row >= 0 && row < length && col >= 0 && col < length);
        }
    }
}
