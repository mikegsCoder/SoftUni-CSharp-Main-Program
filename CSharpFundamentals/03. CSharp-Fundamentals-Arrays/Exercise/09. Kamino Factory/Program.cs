using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int bestLength = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int sequenceCounter = 0;
            int bestSequenceIndex = 0;
            int[] bestSequence = new int[n];

            while (input != "Clone them!")
            {
                int[] currentSequence = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sequenceCounter++;

                int length = 1;
                int bestCurrnetLength = 1;
                int startIndex = 0;
                int currentSequenceSum = 0;

                for (int i = 0; i < currentSequence.Length - 1; i++)
                {
                    if (currentSequence[i] == currentSequence[i + 1])
                    {
                        length++;
                    }
                    else
                    {
                        length = 1;
                    }

                    if (length > bestCurrnetLength)
                    {
                        bestCurrnetLength = length;
                        startIndex = i;
                    }

                    currentSequenceSum += currentSequence[i];
                }

                currentSequenceSum += currentSequence[n - 1];

                if (bestCurrnetLength > bestLength)
                {
                    bestLength = bestCurrnetLength;
                    bestStartIndex = startIndex;
                    bestSequenceSum = currentSequenceSum;
                    bestSequenceIndex = sequenceCounter;
                    bestSequence = currentSequence.ToArray();
                }
                else if (bestCurrnetLength == bestLength)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestLength = bestCurrnetLength;
                        bestStartIndex = startIndex;
                        bestSequenceSum = currentSequenceSum;
                        bestSequenceIndex = sequenceCounter;
                        bestSequence = currentSequence.ToArray();
                    }
                    else if (startIndex == bestStartIndex)
                    {
                        if (currentSequenceSum > bestSequenceSum)
                        {
                            bestLength = bestCurrnetLength;
                            bestStartIndex = startIndex;
                            bestSequenceSum = currentSequenceSum;
                            bestSequenceIndex = sequenceCounter;
                            bestSequence = currentSequence.ToArray();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(' ',bestSequence));
        }
    }
}
