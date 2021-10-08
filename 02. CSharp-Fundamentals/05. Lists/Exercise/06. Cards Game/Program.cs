using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            CardsGame(nums1, nums2);
        }

        static void CardsGame(List<int> nums1, List<int> nums2)
        {
  
            while (nums1.Count > 0 && nums2.Count > 0)
            {
                if(nums1[0] > nums2[0])
                {
                    nums1.Add(nums1[0]);
                    nums1.Add(nums2[0]);
                    nums1.RemoveAt(0);
                    nums2.RemoveAt(0);
                }
                else if (nums2[0] > nums1[0])
                {
                    nums2.Add(nums2[0]);
                    nums2.Add(nums1[0]);
                    nums1.RemoveAt(0);
                    nums2.RemoveAt(0);
                }
                else if (nums1[0] == nums2[0])
                {
                    nums1.RemoveAt(0);
                    nums2.RemoveAt(0);
                }
            }

            if (nums1.Count>0)
            {
                Console.WriteLine($"First player wins! Sum: {nums1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {nums2.Sum()}");
            }
        }
    }
}
