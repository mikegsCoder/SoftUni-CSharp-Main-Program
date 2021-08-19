using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            ChangeList(nums);
        }

        static void ChangeList(List<int> nums)
        {
            string input = string.Empty;

            while((input = Console.ReadLine()) != "end")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand[0] == "Delete")
                {
                    int i = 0;
                    while(i < nums.Count)
                    {
                        if (nums[i] == int.Parse(currentCommand[1].ToString()))
                        {
                            nums.RemoveAt(i);
                            i -= 1;
                        }

                        i++;
                    }
                }

                if (currentCommand[0] == "Insert")
                {
                    nums.Insert(int.Parse(currentCommand[2].ToString()), int.Parse(currentCommand[1].ToString()));
                }
            }

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
