using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int index = int.Parse(Console.ReadLine());
            int sum = 0;

            while (list.Count > 0)
            {
                int num = 0;

                if (index < 0)
                {
                    num = list[0];
                    sum += num;
                    list[0] = list[list.Count - 1];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= num)
                        {
                            list[i] += num;
                        }
                        else if (list[i] > num)
                        {
                            list[i] -= num;
                        }
                    }
                }
                else if (index > list.Count - 1)
                {
                    num = list[list.Count - 1];
                    sum += num;
                    list[list.Count - 1] = list[0];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= num)
                        {
                            list[i] += num;
                        }
                        else if (list[i] > num)
                        {
                            list[i] -= num;
                        }
                    }
                }
                else
                {
                    num = list[index];
                    list.RemoveAt(index);
                    sum += num;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] <= num)
                        {
                            list[i] += num;
                        }
                        else if (list[i] > num)
                        {
                            list[i] -= num;
                        }
                    }

                }

                if (list.Count > 0)
                {
                    index = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
