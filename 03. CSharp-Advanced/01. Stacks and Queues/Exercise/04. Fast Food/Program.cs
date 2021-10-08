using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAvailable = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int maxOrder = orders.Max();

            while (orders.Count > 0)
            {
                if (orders.Peek() <= foodAvailable)
                {
                    foodAvailable -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(maxOrder);

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(' ',orders));
            }
        }
    }
}
