using System;

namespace InvalidNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());

            string validation = "";

            if (num1 == 0 || (num1 >= 100 && num1 <= 200)) validation = "";
            else validation = "invalid";

            Console.WriteLine(validation);
        }
    }
}
