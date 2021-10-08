using System;

namespace _04._CSharp_Fundamentals_Methods_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            DataCalculation(input1, input2);
        }

        static void DataCalculation(string string1, string string2)
        {
            if (string1 == "int")
            {
                Console.WriteLine(int.Parse(string2)*2);
            }
            else if (string1 == "real")
            {
                Console.WriteLine($"{double.Parse(string2)*1.5:f2}");
            }
            else if (string1 == "string")
            {
                Console.WriteLine("$"+string2+"$");
            }
        }
    }
}
