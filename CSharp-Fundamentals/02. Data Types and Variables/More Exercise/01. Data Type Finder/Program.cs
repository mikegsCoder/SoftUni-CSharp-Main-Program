using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int valueInt;
            char valueChar;
            float valueFloat;
            bool valueBool;

            string type;

            while (input != "END")
            {
                if (int.TryParse(input, out valueInt)) type = "integer";
                else if (float.TryParse(input, out valueFloat)) type = "floating point";
                else if (char.TryParse(input, out valueChar)) type = "character";
                else if (bool.TryParse(input, out valueBool)) type = "boolean";
                else type = "string";

                Console.WriteLine($"{input} is {type} type");
                input = Console.ReadLine();
            }
        }
    }
}
