using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CSharp_Fundamentals_Lists_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string textString = Console.ReadLine();

            Console.WriteLine(Messaging(nums, textString));
        }

        static string Messaging(List<int> nums, string textString)
        {
            string output = string.Empty;

            for (int i = 0; i < nums.Count; i++)
            {
                int currentSum = 0;
                string currentElement = nums[i].ToString();

                for (int j = 0; j < currentElement.Length; j++)
                {
                    currentSum += int.Parse(currentElement[j].ToString());
                }

                if (currentSum > textString.Length-1)
                {
                    currentSum -= (currentSum / textString.Length) * textString.Length;
                }

                output += textString.Substring(currentSum, 1);
                textString = textString.Remove(currentSum, 1);                                
            }

            return output;
        }
    }
}
