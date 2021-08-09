using System;

namespace _4._Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            int time = hour * 60 + minute;
            int afterTime = time + 30;
            int afterHour = afterTime / 60;
            int afterMinute = afterTime % 60;
            if (afterHour > 23) afterHour -= 24;
            Console.WriteLine($"{afterHour}:{afterMinute:d2}");
        }
    }
}
