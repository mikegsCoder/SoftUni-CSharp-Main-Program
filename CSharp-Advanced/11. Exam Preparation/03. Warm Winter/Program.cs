using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray());

            List<int> collections = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(currentHat + 1);
                }
                else
                {
                    collections.Add(currentHat + currentScarf);
                    scarfs.Dequeue();
                    hats.Pop();
                }
            }

            Console.WriteLine($"The most expensive set is: {collections.Max()}");
            Console.WriteLine(string.Join(' ',collections));
        }
    }
}
