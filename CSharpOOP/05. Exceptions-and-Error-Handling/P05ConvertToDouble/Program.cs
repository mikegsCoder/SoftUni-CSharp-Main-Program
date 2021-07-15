using System;

namespace P05ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double output;

            try
            {
                output = Convert.ToDouble(input);

                Console.WriteLine(output);                
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }

            Console.WriteLine("---------------");
        }
    }
}
