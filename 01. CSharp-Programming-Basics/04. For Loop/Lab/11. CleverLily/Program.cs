using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double machinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            double money = 0.0;
            double toys = 0;
            double finalSum = 0.0;

            for (int i = 1; i <= lilyAge; i++)
            {
                if (i % 2 == 0) money = money + ((i / 2) * 10)-1;
                if (i % 2 != 0) toys += 1;
            }

            finalSum = (money + toys * toyPrice);

            if (machinePrice <= finalSum) Console.WriteLine($"Yes! {(finalSum-machinePrice):f2}");
            if (machinePrice > finalSum) Console.WriteLine($"No! {(machinePrice - finalSum):f2}");
        }
    }
}
