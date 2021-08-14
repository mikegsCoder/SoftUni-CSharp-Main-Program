using System;
using System.Globalization;

namespace _06._CSharp_Fundamentals_Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateString = Console.ReadLine();

            DateTime date = DateTime.ParseExact(dateString, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
