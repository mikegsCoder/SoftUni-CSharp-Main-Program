using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split().ToArray();

            int n = int.Parse(Console.ReadLine());

            Queue<string> potatoQueue = new Queue<string>(children);

            int potatoTosses = 0;

            while (potatoQueue.Count > 1)
            {
                potatoTosses++;

                string kid = potatoQueue.Dequeue();

                if (potatoTosses == n)
                {
                    Console.WriteLine($"Removed {kid}");
                    potatoTosses = 0;
                }
                else
                {
                    potatoQueue.Enqueue(kid);
                }
            }

            Console.WriteLine($"Last is {potatoQueue.Dequeue()}");
        }
    }
}
