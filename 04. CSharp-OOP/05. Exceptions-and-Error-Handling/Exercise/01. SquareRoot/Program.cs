using System;

namespace P01SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            try
            {
                int n = int.Parse(s);

                if (n < 0)
                {
                    throw new FormatException("Invalid number");
                }

                double result = Math.Sqrt(n);
                Console.WriteLine(result);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
