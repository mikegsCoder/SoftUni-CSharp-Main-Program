using System;

namespace GreetingByName
{
    class Program
    {
        static void Main(string[] args)
        {           
            string name = Console.ReadLine();

            Console.Write("Hello, ");
            Console.Write(name);
            Console.WriteLine("!");
        }
    }
}
