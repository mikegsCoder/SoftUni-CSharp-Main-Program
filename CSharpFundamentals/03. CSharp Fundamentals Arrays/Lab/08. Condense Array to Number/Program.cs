using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (nums.Length == 1)
            {
                Console.WriteLine(nums[0]);
            }
            else
            {                
                while (nums.Length > 1)
                {
                    int[] condensed = new int[nums.Length - 1];
                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        condensed[i] = nums[i] + nums[i + 1];
                    }

                    nums = new int[condensed.Length];

                    for (int i = 0; i < condensed.Length; i++)
                    {                        
                        nums[i] = condensed[i];
                    }
                }

                Console.WriteLine(nums[0]);
            }
        }
    }
}