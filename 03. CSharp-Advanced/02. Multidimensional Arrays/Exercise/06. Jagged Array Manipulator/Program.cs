using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jugged = new double[n][];

            for (int row = 0; row < n; row++)
            {
                jugged[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int row = 1; row < n; row++)
            {
                if (jugged[row - 1].Length == jugged[row].Length)
                {
                    for (int i = 0; i < jugged[row].Length; i++)
                    {
                        jugged[row - 1][i] *= 2;
                        jugged[row][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jugged[row - 1].Length; i++)
                    {
                        jugged[row - 1][i] /= 2;
                    }
                    for (int i = 0; i < jugged[row].Length; i++)
                    {
                        jugged[row][i] /= 2;
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] currentCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(currentCommand[1]);
                int col = int.Parse(currentCommand[2]);
                int value = int.Parse(currentCommand[3]);

                if (row >= 0 && row < jugged.Length && col >= 0 && col < jugged[row].Length)
                {
                    switch (currentCommand[0])
                    {
                        case "Add":
                            jugged[row][col] += value;
                            break;
                        case "Subtract":
                            jugged[row][col] -= value;
                            break;
                    }
                }
            }

            PrintMatrix(jugged);
        }
        static void PrintMatrix(double[][] jugged)
        {
            for (int row = 0; row < jugged.Length; row++)
            {
                Console.WriteLine(string.Join(' ',jugged[row]));
            }
        }
    }
}
