using System;

namespace _5._Month_Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());

            if (month == 1) Console.WriteLine("January");
            if (month == 2) Console.WriteLine("February");
            if (month == 3) Console.WriteLine("March");
            if (month == 4) Console.WriteLine("April");
            if (month == 5) Console.WriteLine("May");
            if (month == 6) Console.WriteLine("June");
            if (month == 7) Console.WriteLine("July");
            if (month == 8) Console.WriteLine("August");
            if (month == 9) Console.WriteLine("September");
            if (month == 10) Console.WriteLine("October");
            if (month == 11) Console.WriteLine("November");
            if (month == 12) Console.WriteLine("December");
            if (month < 1 || month > 12) Console.WriteLine("Error!");
        }
    }
}
