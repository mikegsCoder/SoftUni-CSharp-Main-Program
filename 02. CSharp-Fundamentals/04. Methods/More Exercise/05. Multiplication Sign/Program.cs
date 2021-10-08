using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            MultiplicationSign(num1, num2, num3);
        }

        static void MultiplicationSign(int num1, int num2, int num3)
        {
            if (num1==0 || num2==0 || num3==0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                int negativeCounter = 0;
                if (num1 < 0) negativeCounter++;
                if (num2 < 0) negativeCounter++;
                if (num3 < 0) negativeCounter++;

                if(negativeCounter==1 || negativeCounter == 3)
                {
                    Console.WriteLine("negative");
                }
                else
                {
                    Console.WriteLine("positive");
                }
            }
        }
    }
}
