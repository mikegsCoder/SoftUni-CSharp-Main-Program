using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string isBigger = "";
            float biggerVolume = 0;

            for (int i = 1; i <= n; i++)
            {
                string currentModel = Console.ReadLine();
                float currentRadius = float.Parse(Console.ReadLine());
                float currentHeight = float.Parse(Console.ReadLine());
                float currentVolume = (float)Math.PI * (float)Math.Pow(currentRadius, 2) * currentHeight;
                
                if(currentVolume > biggerVolume)
                {
                    biggerVolume = currentVolume;
                    isBigger = currentModel;
                }
            }

            Console.WriteLine(isBigger);
        }
    }
}
