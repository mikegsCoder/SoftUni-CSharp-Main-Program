using System;

namespace VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {  
            int pages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            double hoursPerDay = pages / pagesPerHour / numberOfDays;

            Console.WriteLine(hoursPerDay);
        }
    }
}
