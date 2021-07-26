using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {            
            int wavesCounter = 0;
            bool arePlatesRecharged = false;

            int currentPlate = 0;
            int currentOrc = 0;

            int numberOfWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse));


            Stack<int> orcs = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse));

            wavesCounter++;

            while (true)
            {
                if (currentPlate == 0)
                {
                    currentPlate = plates.Dequeue();
                }

                if (currentOrc == 0)
                {
                    currentOrc = orcs.Pop();
                }

                if (currentOrc < currentPlate)
                {
                    currentPlate -= currentOrc;
                    currentOrc = 0;
                }
                else if (currentOrc > currentPlate)
                {
                    currentOrc -= currentPlate;
                    currentPlate = 0;
                }
                else
                {
                    currentOrc = 0;
                    currentPlate = 0;
                }

                if (wavesCounter == numberOfWaves && (orcs.Count == 0 && currentOrc == 0) 
                    || (plates.Count == 0 && currentPlate == 0))
                {
                    break;
                }

                if (orcs.Count == 0 && wavesCounter < numberOfWaves)
                {
                    int[] newWave = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();

                    for (int j = 0; j < newWave.Length; j++)
                    {
                        orcs.Push(newWave[j]);
                    }

                    wavesCounter++;
                    arePlatesRecharged = false;
                }               

                if (wavesCounter % 3 == 0 && !arePlatesRecharged)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                    arePlatesRecharged = true;
                }
            }

            if (currentOrc > 0 || orcs.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                if (currentOrc > 0)
                {
                    Console.WriteLine($"Orcs left: {currentOrc}, " + string.Join(", ", orcs));
                }
                else
                {
                    Console.WriteLine($"Orcs left: " + string.Join(", ", orcs));
                }
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                if (currentPlate > 0)
                {
                    Console.WriteLine($"Plates left: {currentPlate}, " + string.Join(", ", plates));
                }
                else
                {
                    Console.WriteLine($"Plates left: " + string.Join(", ", plates));
                }
            }
        }
    }
}
