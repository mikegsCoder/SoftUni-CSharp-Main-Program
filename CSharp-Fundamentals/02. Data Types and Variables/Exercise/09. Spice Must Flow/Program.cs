using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int days = 0;
            int spiceCollected = 0;

            while (n >= 100)
            {
                days += 1;
                spiceCollected += n - 26;
                n -= 10;
            }

            spiceCollected -= 26;

            if (spiceCollected < 0) spiceCollected = 0;

            Console.WriteLine(days);
            Console.WriteLine(spiceCollected);
        }
    }
}
