using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;
            BigInteger bestSnowballValue = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowballVallue = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);
                
                if (currentSnowballVallue > bestSnowballValue)
                {
                    bestSnowballSnow = currentSnowballSnow;
                    bestSnowballTime = currentSnowballTime;
                    bestSnowballQuality = currentSnowballQuality;
                    bestSnowballValue = currentSnowballVallue;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
        }
    }
}
