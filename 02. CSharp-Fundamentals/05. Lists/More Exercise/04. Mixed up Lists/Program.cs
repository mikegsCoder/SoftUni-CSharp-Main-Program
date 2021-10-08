using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            int listLength = Math.Min(nums1.Count, nums2.Count);

            nums2.Reverse();
            List<int> result = new List<int>();

            for (int i = 0; i < listLength; i++)
            {
                result.Add(nums1[i]);
                result.Add(nums2[i]);
            }

            int num1 = 0;
            int num2 = 0;

            if (nums1.Count < nums2.Count)
            {
                num1 = nums2[listLength];
                num2 = nums2[listLength + 1];
            }
            else
            {
                num1 = nums1[listLength];
                num2 = nums1[listLength + 1];
            }

            int minNum = Math.Min(num1, num2);
            int maxNum = Math.Max(num1, num2);

            result.RemoveAll(i => i <= minNum || i >= maxNum);
            result.Sort();

            Console.WriteLine(string.Join(' ',result));
        }
    }
}
