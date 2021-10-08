using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            for (int i = input.Count-1; i >= 0; i--)
            {
                List<int> currentElement = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                Console.Write(string.Join(" ",currentElement) +" ");
            }
        }
    }
}
