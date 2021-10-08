using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNumber = i.ToString();
                int counter = 0;

                for (int j = 0; j < 4; j++)
                {
                    if(int.Parse(currentNumber[j].ToString()) !=0 && n % int.Parse(currentNumber[j].ToString()) == 0 )
                    {
                        counter++;
                    }
                }

                if (counter==4)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
