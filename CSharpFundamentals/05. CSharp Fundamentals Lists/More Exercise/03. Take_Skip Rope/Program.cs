using System;
using System.Collections.Generic;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    numbers.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(input[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int currentIndex = 0;
            List<char> result = new List<char>();

            for (int i = 0; i < takeList.Count; i++)
            {
                List<char> temp = new List<char>();
                int takeIndex = takeList[i];

                if (currentIndex + takeIndex > nonNumbers.Count - 1)
                {
                    takeIndex = nonNumbers.Count - currentIndex;
                }

                temp = nonNumbers.GetRange(currentIndex, takeIndex);
                result.AddRange(temp);
                currentIndex += takeIndex + skipList[i];
            }

            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
