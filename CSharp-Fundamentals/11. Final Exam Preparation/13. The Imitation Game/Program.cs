using System;
using System.Linq;

namespace _13.The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] currentCommand = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentCommand[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(currentCommand[1]);
                        string stringToMove = message.Substring(0, numberOfLetters);
                        message = message.Remove(0, numberOfLetters);
                        message += stringToMove;
                        break;
                    case "Insert":
                        int indexToInsert = int.Parse(currentCommand[1]);
                        string valueToInsert = currentCommand[2];
                        message = message.Insert(indexToInsert, valueToInsert);
                        break;
                    case "ChangeAll":
                        string oldString = currentCommand[1];
                        string newString = currentCommand[2];
                        while (message.Contains(oldString))
                        {
                            message = message.Replace(oldString, newString);
                        }
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
