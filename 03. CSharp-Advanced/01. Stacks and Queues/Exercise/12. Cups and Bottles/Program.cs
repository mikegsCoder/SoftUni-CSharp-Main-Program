using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedLiters = 0;
            int allBottles = bottles.Count;
            int allCups = cups.Count;
            
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();

                while (currentCup > 0 && bottles.Count > 0 && cups.Count > 0)
                { 
                    int currentBottle = bottles.Pop();

                    if (currentBottle - currentCup >= 0)
                    {
                        wastedLiters += currentBottle - currentCup;
                        cups.Dequeue();
                        currentCup = 0;
                    }
                    else
                    {
                        currentCup -= currentBottle;
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ',bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
