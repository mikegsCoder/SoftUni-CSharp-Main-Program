using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = numbers[0];
            int s = numbers[1];
            int x = numbers[2];

            int[] numsToPush = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> elements = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                elements.Enqueue(numsToPush[i]);
            }

            for (int i = 0; i < s; i++)
            {
                elements.Dequeue();
            }

            if (elements.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (elements.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minElement = elements.Dequeue();
                while (elements.Count > 0)
                {
                    minElement = Math.Min(minElement, elements.Dequeue());
                }

                Console.WriteLine(minElement);
            }
        }
    }
}
