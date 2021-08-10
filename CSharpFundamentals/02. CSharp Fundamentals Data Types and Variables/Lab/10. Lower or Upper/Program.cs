using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            int x = (int)input;

            if (65 <= x && x <= 90) Console.WriteLine("upper-case");
            if (97 <= x && x <= 122) Console.WriteLine("lower-case");
        }
    }
}
