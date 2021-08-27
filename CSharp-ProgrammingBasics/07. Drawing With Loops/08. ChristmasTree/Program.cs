using System;

namespace ChristmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                Console.Write(new string(' ',n-i));
                Console.Write(new string('*',i));
                Console.Write(" | ");
                Console.Write(new string('*', i));
                Console.Write(new string(' ', n - i));
                Console.WriteLine();
            }
        }
    }
}
