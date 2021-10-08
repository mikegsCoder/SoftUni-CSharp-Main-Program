using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            List<int> currentDrumSet = new List<int>();

            currentDrumSet.AddRange(drumSet);

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);
                int i = 0;

                while (i < currentDrumSet.Count)
                {
                    currentDrumSet[i] -= hitPower;

                    if (currentDrumSet[i] <= 0)
                    {
                        if (savings >= drumSet[i] * 3)
                        {
                            currentDrumSet[i] = drumSet[i];
                            savings -= drumSet[i] * 3;
                        }
                        else
                        {
                            currentDrumSet.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i--;
                        }
                    }

                    i++;
                }

            }

            Console.WriteLine(string.Join(' ', currentDrumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
