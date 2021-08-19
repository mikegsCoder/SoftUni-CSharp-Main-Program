using System;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split();
            int[] nums = new int[splitted.Length];

            int sum = 0;

            for (int i = 0; i < splitted.Length; i++)
            {
                nums[i] = int.Parse(splitted[i]);

                if (nums[i]%2 == 0)
                {
                    sum += nums[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
