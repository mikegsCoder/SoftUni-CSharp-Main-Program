using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagedArr[row] = new int[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jagedArr[row][col] = rowData[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] currentCommand = input.Split();

                int row = int.Parse(currentCommand[1]);
                int col = int.Parse(currentCommand[2]);
                int value = int.Parse(currentCommand[3]);

                if (row<0 || row >= jagedArr.Length || col<0 || col >= jagedArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                else
                {
                    switch (currentCommand[0])
                    {
                        case "Add":
                            jagedArr[row][col] += value;
                            break;
                        case "Subtract":
                            jagedArr[row][col] -= value;
                            break;
                    }
                }
            }

            for (int row = 0; row < jagedArr.Length; row++)
            { 
                Console.WriteLine(string.Join(' ',jagedArr[row])); 
            }
        }
    }
}
