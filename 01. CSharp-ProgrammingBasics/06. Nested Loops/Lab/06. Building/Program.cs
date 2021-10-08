using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floors; i >=1 ; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i % 2 == 0 && i < floors)
                    {
                        if (j < rooms - 1) Console.Write($"O{i}{j} ");
                        else Console.Write($"O{i}{j}");
                    }

                    if (i % 2 != 0 && i < floors)
                    {
                        if (j < rooms - 1) Console.Write($"A{i}{j} ");
                        else Console.Write($"A{i}{j}");
                    }

                    if (i == floors)
                    {
                        if (j < rooms - 1) Console.Write($"L{i}{j} ");
                        else Console.Write($"L{i}{j}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
