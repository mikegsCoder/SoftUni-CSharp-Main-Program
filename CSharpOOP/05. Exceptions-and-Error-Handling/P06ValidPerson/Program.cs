using System;
using P06ValidPerson.Exceptions;

namespace P06ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person pesho = new Person("Pesho", "Peshev", 24);
                              
                Person negativeAge = new Person("Sto4yan", "Kolev", -1);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}",ane.Message);
            }
            catch (MyCustomException mce)
            {
                Console.WriteLine(mce.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
        }
    }
}
