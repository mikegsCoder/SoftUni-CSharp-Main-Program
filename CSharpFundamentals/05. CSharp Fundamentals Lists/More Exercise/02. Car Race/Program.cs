using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            CarRace(list);
        }
        static void CarRace(List<int> list)
        {
            List<int> firstTrack = list.GetRange(0, (list.Count - 1) / 2);
            List<int> secondTrack = list.GetRange((list.Count + 1) / 2, (list.Count - 1) / 2);
            secondTrack.Reverse();

            double firstCarTime = 0;
            double secondCarTime = 0;

            for (int i = 0; i < firstTrack.Count; i++)
            {
                if (firstTrack[i] == 0)
                {
                    firstCarTime *= 0.8;
                }
                else if (firstTrack[i] > 0)
                {
                    firstCarTime += firstTrack[i];
                }

                if (secondTrack[i] == 0)
                {
                    secondCarTime *= 0.8;
                }
                else 
                {
                    secondCarTime += secondTrack[i];
                }
            }

            if (firstCarTime < secondCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstCarTime}");
            }
            else if(secondCarTime < firstCarTime) 
            {
                Console.WriteLine($"The winner is right with total time: {secondCarTime}");
            }
        }
    }
}
