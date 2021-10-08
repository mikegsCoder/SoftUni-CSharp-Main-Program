using System;

namespace _02.AND_Processors
{
    class Program
    {
        static void Main(string[] args)
        {
            int processorsPlanned = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workingDays = int.Parse(Console.ReadLine());

            int processorsProduced = workers * workingDays * 8 / 3;

            if (processorsPlanned > processorsProduced)
            {
                Console.WriteLine($"Losses: -> {(processorsPlanned - processorsProduced)*110.10:f2} BGN");
            }
            else
            {
                Console.WriteLine($"Profit: -> {(processorsProduced - processorsPlanned) * 110.10:f2} BGN");
            }
        }
    }
}
