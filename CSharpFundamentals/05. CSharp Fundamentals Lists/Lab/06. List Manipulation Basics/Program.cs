using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            ListManipulation(nums);
        }

        static void ListManipulation(List<int> nums)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand[0] == "Add")
                {
                    nums.Add(int.Parse(currentCommand[1].ToString()));
                }

                if (currentCommand[0] == "Remove")
                {
                    nums.Remove(int.Parse(currentCommand[1].ToString()));
                }

                if (currentCommand[0] == "RemoveAt")
                {
                    nums.RemoveAt(int.Parse(currentCommand[1].ToString()));
                }

                if (currentCommand[0] == "Insert")
                {
                    nums.Insert(int.Parse(currentCommand[2].ToString()), int.Parse(currentCommand[1].ToString()));
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
