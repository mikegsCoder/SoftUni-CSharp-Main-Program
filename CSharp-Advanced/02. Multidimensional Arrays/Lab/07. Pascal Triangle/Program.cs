using System;
using System.Numerics;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            BigInteger[][] pascalsTriangle = new BigInteger[rows][];
            
            if (rows == 1)
            {
                Console.WriteLine("1");
            }
            else if (rows == 2)
            {
                Console.WriteLine("1 1");
            }
            else
            {
                pascalsTriangle[0] = new BigInteger[1] { 1 };
                pascalsTriangle[1] = new BigInteger[2] { 1, 1 };

                for (int row = 2; row < rows; row++)
                {
                    pascalsTriangle[row] = new BigInteger[row + 1];

                    for (int col = 0; col <= row; col++)
                    {
                        if (col == 0 || col == row)
                        {
                            pascalsTriangle[row][col] = 1;
                        }
                        else
                        {
                            pascalsTriangle[row][col] = pascalsTriangle[row - 1][col] + pascalsTriangle[row - 1][col - 1];
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine(string.Join(' ',pascalsTriangle[row]));
                }
            }
        }
    }
}
