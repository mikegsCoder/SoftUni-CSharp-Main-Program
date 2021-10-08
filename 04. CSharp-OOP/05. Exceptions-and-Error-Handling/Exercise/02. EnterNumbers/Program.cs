using System;

namespace P02EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int start = 1;
            int end = 100;
            bool haveTenNumbers = false;

            while (haveTenNumbers == false)
            {
                try
                {
                    ReadNumber(start, end, arr);

                    haveTenNumbers = true;
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine(aore.Message);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        public static void ReadNumber(int start, int end, int[] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                int n = int.Parse(Console.ReadLine());

                if (n <= start || n >= end)
                {
                    throw new ArgumentOutOfRangeException
                        (String.Format("number must be between {0} and {1}, start, end"));
                }

                arr[i] = n;
            }
        }
    }
}
