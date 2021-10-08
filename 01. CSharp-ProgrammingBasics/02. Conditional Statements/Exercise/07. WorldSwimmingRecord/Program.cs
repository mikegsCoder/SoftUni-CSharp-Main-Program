using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double additionalTime = Math.Floor(distance / 15) * 12.5;
            double ivanchosTime = Math.Round((timeForMeter * distance + additionalTime),2);

            if (ivanchosTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanchosTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(ivanchosTime-record):f2} seconds slower.");
            }
        }
    }
}
