using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            bool isEqual = true;

            if (input1 == input2)
            {
                isEqual = true;
            }
            else
            {
                isEqual = false;
            }

            int[] nums1 = input1.Split().Select(int.Parse).ToArray();
            int[] nums2 = input2.Split().Select(int.Parse).ToArray();

            if (isEqual)
            {
                int sum = 0;
                for (int i = 0; i < nums1.Length; i++)
                {
                    sum += nums1[i];
                }

                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                for (int i = 0; i < nums1.Length; i++)
                {
                    if(nums1[i] != nums2[i])
                    {
                        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                        break;
                    }
                }
            }
        }
    }
}
