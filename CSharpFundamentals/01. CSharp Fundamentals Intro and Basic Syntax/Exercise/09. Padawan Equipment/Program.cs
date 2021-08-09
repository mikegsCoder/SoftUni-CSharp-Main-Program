using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double ammountOfMoney = double.Parse(Console.ReadLine());
            double countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            double expence = priceOfLightsaber * Math.Ceiling(countOfStudents * 1.1) + priceOfRobe * countOfStudents + priceOfBelt * (countOfStudents - Math.Floor(countOfStudents / 6));
            
            if(expence <= ammountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {expence:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {expence - ammountOfMoney:f2}lv more.");
            }
        }
    }
}
