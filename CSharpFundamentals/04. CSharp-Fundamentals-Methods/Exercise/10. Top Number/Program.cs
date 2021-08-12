using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            TopNumberDeterminer(n);
        }

        static void TopNumberDeterminer(int n)
        {
            for (int i = 8; i <= n; i++)
            {
                string input = i.ToString();
                int sum = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    sum += int.Parse(input[j].ToString());
                }

                if (sum % 8 == 0)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (int.Parse(input[j].ToString()) % 2 != 0)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }
        }
    }
}
