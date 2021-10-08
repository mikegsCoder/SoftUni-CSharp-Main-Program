using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            switch (town)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500) Console.WriteLine($"{sales*0.05:f2}");        //comission = 5;
                    if (sales > 500 && sales <= 1000) Console.WriteLine($"{sales * 0.07:f2}");    //comission = 7;
                    if (sales > 1000 && sales <= 10000) Console.WriteLine($"{sales * 0.08:f2}");  //comission = 8;
                    if (sales > 10000) Console.WriteLine($"{sales * 0.12:f2}");                   //comission = 12;
                    if (sales < 0) Console.WriteLine("error");
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500) Console.WriteLine($"{sales * 0.045:f2}");     //comission = 4.5;
                    if (sales > 500 && sales <= 1000) Console.WriteLine($"{sales * 0.075:f2}");   //comission = 7.5;
                    if (sales > 1000 && sales <= 10000) Console.WriteLine($"{sales * 0.10:f2}");  //comission = 10;
                    if (sales > 10000) Console.WriteLine($"{sales * 0.13:f2}");                   //comission = 13;
                    if (sales < 0) Console.WriteLine("error");
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500) Console.WriteLine($"{sales * 0.055:f2}");     //comission = 5.5;
                    if (sales > 500 && sales <= 1000) Console.WriteLine($"{sales * 0.08:f2}");    //comission = 8;
                    if (sales > 1000 && sales <= 10000) Console.WriteLine($"{sales * 0.12:f2}");  //comission = 12;
                    if (sales > 10000) Console.WriteLine($"{sales * 0.145:f2}");                  //comission = 14.5;
                    if (sales < 0) Console.WriteLine("error");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
