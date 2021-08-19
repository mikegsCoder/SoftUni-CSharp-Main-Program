using System;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359([\s-])2\1\d{3}\1\d{4}\b";

            string phoneNumberString = Console.ReadLine();

            var numbers = Regex.Matches(phoneNumberString, regex);
             
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
