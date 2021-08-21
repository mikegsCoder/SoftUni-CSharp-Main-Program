using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            if ((minute + 15) < 60) Console.WriteLine($"{hour}:{minute+15}");
            if ((minute + 15) == 60 & hour == 23) Console.WriteLine($"0:00");
            if ((minute + 15) == 60 & hour < 23) Console.WriteLine($"{hour+1}:00");
            if ((minute + 15) > 60 & (minute - 45) >= 10 & hour == 23) Console.WriteLine($"0:{minute - 45}");
            if ((minute + 15) > 60 & (minute - 45) < 10 & hour == 23) Console.WriteLine($"0:0{minute - 45}");
            if ((minute + 15) > 60 & (minute - 45) >= 10 & hour < 23) Console.WriteLine($"{hour + 1}:{minute - 45}");
            if ((minute + 15) > 60 & (minute - 45) < 10 & hour < 23) Console.WriteLine($"{hour + 1}:0{minute - 45}");
        }
    }
}
