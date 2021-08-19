using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] special = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int specialBombNumber = special[0];
            int specialBombPower = special[1];

            Console.WriteLine(BombOperations(nums, specialBombNumber, specialBombPower));
        }

        static int BombOperations(List<int> nums, int bombNumber, int bombPower)
        {
            while (nums.IndexOf(bombNumber) >= 0)
            {
                int bombIndex = nums.IndexOf(bombNumber);
                int leftNum = bombIndex - bombPower;
                if (leftNum < 0) leftNum = 0;
                int rightNum = bombIndex + bombPower;
                int range = rightNum - leftNum +1;
                if (leftNum + range > nums.Count) range = nums.Count - leftNum;
                nums.RemoveRange(leftNum, range);
            }

            int sum = nums.Sum();
            return sum;
        }
    }
}
