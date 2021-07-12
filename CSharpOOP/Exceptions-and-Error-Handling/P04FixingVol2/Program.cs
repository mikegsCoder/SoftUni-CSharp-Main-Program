using System;

namespace P04FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());

            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }

            Console.ReadLine();
        }
    }
}
