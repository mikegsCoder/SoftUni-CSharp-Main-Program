using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            ListOperations(nums);
        }

        static void ListOperations(List<int> nums)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand[0] == "Add")
                {
                    nums.Add(int.Parse(currentCommand[1]));
                }

                if (currentCommand[0] == "Remove")
                {
                    if (int.Parse(currentCommand[1]) < 0 ||
                        int.Parse(currentCommand[1]) >= nums.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.RemoveAt(int.Parse(currentCommand[1]));
                    }
                }
 
                if (currentCommand[0] == "Insert")
                {
                    if (int.Parse(currentCommand[2]) < 0 ||
                        int.Parse(currentCommand[2]) >= nums.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.Insert(int.Parse(currentCommand[2]), int.Parse(currentCommand[1]));
                    }
                }

                if (currentCommand[0] == "Shift")
                {

                    if (currentCommand[1] == "left")
                    { 
                        int count = int.Parse(currentCommand[2]);

                        for (int i = 1; i <= count; i++)
                        {
                            int firstNum = nums[0];
                            nums.Add(firstNum);
                            nums.RemoveAt(0);
                        }

                    }
                    else
                    {
                        int count = int.Parse(currentCommand[2]);

                        for (int i = 1; i <= count; i++)
                        {
                            int lastNum = nums[nums.Count-1];
                            nums.Insert(0,lastNum);
                            nums.RemoveAt(nums.Count-1);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
