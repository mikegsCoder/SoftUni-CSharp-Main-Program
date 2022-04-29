using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {            
            int depositAmmount = int.Parse(Console.ReadLine());
            int depositPeriod = int.Parse(Console.ReadLine());
            double annualInterest = double.Parse(Console.ReadLine());
            double finalAmmount = depositAmmount + depositPeriod * ((depositAmmount * annualInterest/100) / 12);
            
            Console.WriteLine(finalAmmount);
        }
    }
}
