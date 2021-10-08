using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] initialField = new int[n];

            for (int i = 0; i < inputIndexes.Length; i++)
            {
                if (inputIndexes[i] >= 0 && inputIndexes[i] < n)
                {
                    initialField[inputIndexes[i]] = 1;
                }
            }

            string currentInput = string.Empty;

            while ((currentInput = Console.ReadLine()) != "end")
            {
                string[] flyingCommand = currentInput.Split().ToArray();

                int ladybugIndex = int.Parse(flyingCommand[0]);
                int flyLength = int.Parse(flyingCommand[2]);
                                
                int landingIndex = ladybugIndex;

                if (ladybugIndex >= 0 && ladybugIndex < n && initialField[ladybugIndex] == 1)
                {
                    initialField[ladybugIndex] = 0;
                    if (flyingCommand[1] == "right")
                    {
                        landingIndex += flyLength;
                        while (landingIndex >= 0 && landingIndex < n)
                        {
                            if (initialField[landingIndex] == 0)
                            {
                                initialField[landingIndex] = 1;
                                break;
                            }

                            landingIndex += flyLength;
                        }
                    }

                    if (flyingCommand[1] == "left")
                    {
                        landingIndex -= flyLength;
                        while (landingIndex >= 0 && landingIndex < n)
                        {
                            if (initialField[landingIndex] == 0)
                            {
                                initialField[landingIndex] = 1;
                                break;
                            }

                            landingIndex -= flyLength;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(' ', initialField));
        }
    }
}
