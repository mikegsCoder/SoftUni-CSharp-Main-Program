using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != "stop")
            {
                int currentInput = int.Parse(input);
                bool isNonPrime = false;

                if (currentInput < 0)
                {
                    Console.WriteLine("Number is negative.");
                    currentInput = 0;
                }

                if (currentInput == 0 || currentInput == 1)
                {
                    nonPrimeSum += currentInput;
                    isNonPrime = true;
                }
                else
                {
                    for (int a = 2; a <= currentInput / 2; a++)
                    {
                        if (currentInput % a == 0)
                        {
                            nonPrimeSum += currentInput;
                            isNonPrime = true;
                            break;
                        }
                    }

                    if (!isNonPrime) primeSum += currentInput;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
