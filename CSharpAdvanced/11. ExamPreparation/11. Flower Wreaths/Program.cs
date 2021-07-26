using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int wreathsCount = 0;
            int storedFlowers = 0;

            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currLilie = lilies.Pop();
                int currRose = roses.Dequeue();

                if (currLilie + currRose == 15)
                {
                    wreathsCount++;
                }
                else if (currLilie + currRose > 15)
                {
                    while (currLilie + currRose > 15)
                    {
                        currLilie -= 2;

                        if (currLilie + currRose == 15)
                        {
                            wreathsCount++;
                        }
                    }
                }

                if (currLilie + currRose < 15)
                {
                    storedFlowers += currLilie + currRose;
                }
            }

            wreathsCount += storedFlowers / 15;

            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreathsCount} wreaths more!");
            }
        }
    }
}
