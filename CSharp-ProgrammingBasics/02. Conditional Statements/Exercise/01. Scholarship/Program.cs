using System;

namespace Scholarship_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageMark = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialSchoolarship = minSalary * 0.35;
            double excellenceSchoolarship = averageMark * 25;
            string output = "You cannot get a scholarship!";

            if (income < minSalary & averageMark > 4.50)
            {
                if (averageMark < 5.50) output = ($"You get a Social scholarship {Math.Floor(socialSchoolarship)} BGN");
                else if (averageMark >= 5.50 & socialSchoolarship > excellenceSchoolarship) output = ($"You get a Social scholarship {Math.Floor(socialSchoolarship)} BGN");
                else output = ($"You get a scholarship for excellent results {Math.Floor(excellenceSchoolarship)} BGN");
            }
            if (income >= minSalary & averageMark >= 5.50)
            {
                output = ($"You get a scholarship for excellent results {Math.Floor(excellenceSchoolarship)} BGN");
            }

            Console.WriteLine(output);
        }
    }
}
