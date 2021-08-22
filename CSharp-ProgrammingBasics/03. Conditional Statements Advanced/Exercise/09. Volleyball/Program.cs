using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine(); 
            int p = int.Parse(Console.ReadLine()); 
            int h = int.Parse(Console.ReadLine());

            double pp = p;
            double hh = h;
            double games = (48 - hh) * 3 / 4 + hh + pp * 2/3;

            switch (yearType)
            {
                case "leap":
                    games = games * 1.15;
                    break;
            }

            Console.WriteLine($"{Math.Floor(games)}");
        }
    }
}
