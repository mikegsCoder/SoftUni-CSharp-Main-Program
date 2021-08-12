using System;

namespace _03._CSharp_Fundamentals_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dates = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Console.WriteLine(dates[0]);
                    break;
                case 2:
                    Console.WriteLine(dates[1]);
                    break;
                case 3:
                    Console.WriteLine(dates[2]);
                    break;
                case 4:
                    Console.WriteLine(dates[3]);
                    break;
                case 5:
                    Console.WriteLine(dates[4]);
                    break;
                case 6:
                    Console.WriteLine(dates[5]);
                    break;
                case 7:
                    Console.WriteLine(dates[6]);
                    break;
                default:
                    Console.WriteLine("Invalid day!");
                    break;
            }
        }
    }
}
