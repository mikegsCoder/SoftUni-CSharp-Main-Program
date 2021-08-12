using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Repeatstring(input,n));
        }
        private static string Repeatstring(string input, int n)
        {
            string result = "";
            for (int i = 1; i <= n; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
