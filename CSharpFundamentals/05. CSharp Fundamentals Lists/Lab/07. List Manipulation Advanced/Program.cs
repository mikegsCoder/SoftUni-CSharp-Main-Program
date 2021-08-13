using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
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
            bool isChanged = false;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand[0] == "Contains")
                {
                    if (nums.Contains(int.Parse(currentCommand[1].ToString())))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }

                if (currentCommand[0] == "PrintEven")
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] % 2 == 0)
                        {
                            Console.Write($"{nums[i]} ");
                        }
                    }

                    Console.WriteLine();
                }

                if (currentCommand[0] == "PrintOdd")
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] % 2 != 0)
                        {
                            Console.Write($"{nums[i]} ");
                        }
                    }

                    Console.WriteLine();
                }

                if (currentCommand[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i = 0; i < nums.Count; i++)
                    {
                        sum += nums[i];
                    }

                    Console.WriteLine(sum);
                }

                if (currentCommand[0] == "Filter")
                {
                    if (currentCommand[1] == ">")
                    {
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] > int.Parse(currentCommand[2].ToString()))
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                    if (currentCommand[1] == ">=")
                    {
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] >= int.Parse(currentCommand[2].ToString()))
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                    if (currentCommand[1] == "<")
                    {
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] < int.Parse(currentCommand[2].ToString()))
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                    if (currentCommand[1] == "<=")
                    {
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] <= int.Parse(currentCommand[2].ToString()))
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }

                        Console.WriteLine();
                    }
                }

                if (currentCommand[0] == "Add")
                {
                    nums.Add(int.Parse(currentCommand[1].ToString()));
                    isChanged = true;
                }

                if (currentCommand[0] == "Remove")
                {
                    nums.Remove(int.Parse(currentCommand[1].ToString()));
                    isChanged = true;
                }

                if (currentCommand[0] == "RemoveAt")
                {
                    nums.RemoveAt(int.Parse(currentCommand[1].ToString()));
                    isChanged = true;
                }

                if (currentCommand[0] == "Insert")
                {
                    nums.Insert(int.Parse(currentCommand[2].ToString()), int.Parse(currentCommand[1].ToString()));
                    isChanged = true;
                }

            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
