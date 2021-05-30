
using System;

namespace CSharpFundamentals_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            string message = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currCommand = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (currCommand[0])
                {
                    case "Translate":
                        string strToTranslate = currCommand[1];
                        string strToReplace = currCommand[2];

                        while (message.Contains(strToTranslate))
                        {
                            message = message.Replace(strToTranslate, strToReplace);
                        }

                        Console.WriteLine(message);
                        break;
                    case "Includes":
                        string strToInclude = currCommand[1];

                        if (message.Contains(strToInclude))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Start":
                        string strToStart = currCommand[1];

                        if (message.StartsWith(strToStart))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Lowercase":
                        message = message.ToLower();

                        Console.WriteLine(message);
                        break;
                    case "FindIndex":
                        string charToFind = currCommand[1];

                        Console.WriteLine(message.LastIndexOf(charToFind));
                        break;
                    case "Remove":
                        int startIndexToRemove = int.Parse(currCommand[1]);
                        int countToRemove = int.Parse(currCommand[2]);

                        message = message.Remove(startIndexToRemove, countToRemove);

                        Console.WriteLine(message);
                        break;
                }
            }
        }
    }
}
