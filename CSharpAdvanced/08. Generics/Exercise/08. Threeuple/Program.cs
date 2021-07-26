using System;

namespace P08Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] threeupleData = Console.ReadLine().Split();

            if (threeupleData.Length == 5)
            {
                threeupleData[3] += " " + threeupleData[4];
            }

            Threeuple<string, string, string> firstThreeuple =
                new Threeuple<string, string, string>($"{threeupleData[0]} {threeupleData[1]}", threeupleData[2],threeupleData[3]);

            threeupleData = Console.ReadLine().Split();

            if (threeupleData[2] == "drunk")
            {
                threeupleData[2] = "True";
            }
            else
            {
                threeupleData[2] = "False";
            }

            Threeuple<string, int, string> secondThreeuple =
                new Threeuple<string, int, string>(threeupleData[0], int.Parse(threeupleData[1]), threeupleData[2]);

            threeupleData = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdThreeuple =
                new Threeuple<string, double, string>(threeupleData[0], double.Parse(threeupleData[1]), threeupleData[2]);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
