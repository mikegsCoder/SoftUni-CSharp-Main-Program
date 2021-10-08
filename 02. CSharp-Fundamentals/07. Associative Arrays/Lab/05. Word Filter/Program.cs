using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            List<string> evenLength = new List<string>();

            evenLength = words.Where(word => word.Length % 2 == 0).ToList();

            Console.WriteLine(string.Join(Environment.NewLine,evenLength));
        }
    }
}
