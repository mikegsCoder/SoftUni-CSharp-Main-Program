using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());
            string inputUnit = Console.ReadLine();
            string outputUnit = Console.ReadLine();

            if (inputUnit == "mm" & outputUnit == "cm") Console.WriteLine($"{distance/10:f3}");
            else if (inputUnit == "mm" & outputUnit == "m") Console.WriteLine($"{distance/1000:f3}");
            else if (inputUnit == "cm" & outputUnit == "mm") Console.WriteLine($"{distance*10:f3}");
            else if (inputUnit == "cm" & outputUnit == "m") Console.WriteLine($"{distance/100:f3}");
            else if (inputUnit == "m" & outputUnit == "mm") Console.WriteLine($"{distance*1000:f3}");
            else if (inputUnit == "m" & outputUnit == "cm") Console.WriteLine($"{distance*100:f3}");
        }
    }
}
