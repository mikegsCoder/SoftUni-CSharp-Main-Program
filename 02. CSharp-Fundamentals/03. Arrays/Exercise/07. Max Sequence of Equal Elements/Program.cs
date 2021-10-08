using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int longestSequenceIndex = 0;
            int longestSequenceLength = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    int sequenceIndex = i;
                    int sequenceLength = 1;

                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i] == input[j])
                        {
                            sequenceLength += 1;

                            if (sequenceLength > longestSequenceLength)
                            {
                                longestSequenceLength = sequenceLength;
                                longestSequenceIndex = sequenceIndex;
                            }
                        }

                        if (input[i] != input[j])
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = longestSequenceIndex; i < longestSequenceIndex + longestSequenceLength; i++)
            {
                Console.Write(input[i]+" ");
            }
        }
    }
}
