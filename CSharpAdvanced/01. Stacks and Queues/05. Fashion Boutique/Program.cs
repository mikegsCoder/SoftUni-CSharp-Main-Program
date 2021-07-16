using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int rackCapacity = int.Parse(Console.ReadLine());

            int counter = 1;
            int currentRackCapacity = rackCapacity;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= clothes.Pop();
                }
                else
                {
                    counter++;
                    currentRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
