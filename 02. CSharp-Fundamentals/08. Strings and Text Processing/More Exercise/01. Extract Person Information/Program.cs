using System;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string name = input.Substring(input.IndexOf('@') + 1, (input.IndexOf('|') - input.IndexOf('@') - 1));
                string age = input.Substring(input.IndexOf('#') + 1, (input.IndexOf('*') - input.IndexOf('#') - 1));
                name.TrimStart(' ');
                name.TrimEnd(' ');
                age.TrimStart(' ');
                age.TrimEnd(' ');

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
