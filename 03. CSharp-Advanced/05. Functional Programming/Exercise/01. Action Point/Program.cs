using System;

namespace _05._CSharp_Advanced_Functional_Programming_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Printer(names);
        }
        static void Printer(string[] names)
        {
            Action<string> printer = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                printer(name);
            }
        }
    }
}
