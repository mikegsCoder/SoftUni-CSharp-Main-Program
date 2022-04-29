using System;

namespace _06.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string wwwSite = Console.ReadLine();

                switch (wwwSite)
                {
                    case ("Facebook"):
                        salary = salary - 150;
                        break;
                    case ("Instagram"):
                        salary = salary - 100;
                        break;
                    case ("Reddit"):
                        salary = salary - 50;
                        break;
                }
            }

            if (salary <= 0) Console.WriteLine("You have lost your salary.");
            if (salary > 0) Console.WriteLine(salary);
        }
    }
}
