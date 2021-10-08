using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            char elementToFind = char.Parse(Console.ReadLine());
            int[] elementCoordinates = FindMatrixElement(matrix, elementToFind, n).Split().Select(int.Parse).ToArray();

            if (elementCoordinates[0] >= 0 && elementCoordinates[1] >= 0)
            {
                Console.WriteLine($"({elementCoordinates[0]}, {elementCoordinates[1]})");
            }
            else
            {
                Console.WriteLine($"{elementToFind} does not occur in the matrix");
            }
        }
        static string FindMatrixElement(char[,] matrix, char elementTofind, int n)
        {
            int elementRow = -1;
            int elementCol = -1;
            bool elementFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == elementTofind)
                    {
                        elementRow = row;
                        elementCol = col;
                        elementFound = true;
                        break;
                    }
                }
                if (elementFound)
                {
                    break;
                }
            }

            return ($"{elementRow} {elementCol}");
        }
    }
}
