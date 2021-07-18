using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            HashSet<int> numbersN = new HashSet<int>();
            HashSet<int> numbersM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                numbersN.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                numbersM.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in numbersN)
            {
                if (numbersM.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
