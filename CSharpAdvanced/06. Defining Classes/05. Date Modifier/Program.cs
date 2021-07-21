using System;

namespace _05._Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string dateOneStr = Console.ReadLine();
            string dateTwoStr = Console.ReadLine();
            Console.WriteLine(Math.Abs(DateModifier.GetDiffBetweenDatesInDays(dateOneStr, dateTwoStr)));
        }
    }
}
