using System;

namespace _04.GiftsFromSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            bool equalToS = false;

            for (int i = m; i >= n; i--)
            {
                if (i%2==0 && i % 3 == 0)
                {
                    if(s % 2 == 0 && s % 3 == 0 && i==s)
                    {
                        equalToS = true;
                        break;
                    }

                    if (equalToS)
                    {
                        break;
                    }

                    Console.Write(i+" ");
                }
            }
        }
    }
}
