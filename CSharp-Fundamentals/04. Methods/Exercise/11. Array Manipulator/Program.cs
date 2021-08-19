using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if(command[0] == "exchange")
                {
                    if (int.Parse(command[1]) < 0 || (int.Parse(command[1])) > arr.Length-1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    Exchange(arr, int.Parse(command[1]));
                }
                else if (command[0] == "max")
                {
                    if(command[1] == "even")
                    {
                        if(MaxEven(arr) < 0)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(MaxEven(arr));
                        }
                    }
                    else
                    {
                        if (MaxOdd(arr) < 0)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(MaxOdd(arr));
                        }
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        if (MinEven(arr) < 0)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(MinEven(arr));
                        }
                    }
                    else
                    {
                        if (MinOdd(arr) < 0)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine(MinOdd(arr));
                        }
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if(command[2] == "even")
                    {
                        ReturnFirstEven(arr, count);
                    }
                    else
                    {
                        ReturnFirstOdd(arr, count);
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (command[2] == "even")
                    {
                        ReturnLastEven(arr, count);
                    }
                    else
                    {
                        ReturnLastOdd(arr, count);
                    }
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

        static void Exchange(int[] array, int index)
        {
            int[] firstArray = new int[array.Length - index - 1];
            int[] secondArray = new int[index + 1];

            for (int i = index + 1; i < array.Length; i++)
            {
                firstArray[i - index - 1] = array[i];
            }

            for (int i = 0; i < index +1; i++)
            {
                secondArray[i] = array[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                array[i] = firstArray[i];
            }

            for (int i = firstArray.Length; i < array.Length; i++)
            {
                array[i] = secondArray[i - firstArray.Length];
            }
        }

        static int MaxEven(int[] array)
        {
            int maxEven = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%2 == 0 && array[i] >= maxEven)
                {
                    maxEven = array[i];
                    index = i;
                }
            }

            return index;
        }

        static int MaxOdd(int[] array)
        {
            int maxOdd = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] >= maxOdd)
                {
                    maxOdd = array[i];
                    index = i;
                }
            }

            return index;
        }

        static int MinEven(int[] array)
        {
            int minEven = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] <= minEven)
                {
                    minEven = array[i];
                    index = i;
                }
            }

            return index;
        }

        static int MinOdd(int[] array)
        {
            int minOdd = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] <= minOdd)
                {
                    minOdd = array[i];
                    index = i;
                }
            }

            return index;
        }

        static void ReturnFirstEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            if(counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnFirstOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnLastEven(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >=0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }

        static void ReturnLastOdd(int[] array, int count)
        {
            string numbers = string.Empty;
            int counter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", result) + "]");
            }
        }
    }
}
