using System;
using System.Linq;
using System.Text;

namespace _04._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] currentCommand = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentCommand[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(currentCommand[1]);
                        sb.Insert(index, " ");
                        Console.WriteLine(sb);
                        break;
                    case "Reverse":
                        string stringToReverse = currentCommand[1];

                        if (sb.ToString().Contains(stringToReverse))
                        {
                            string reversed = string.Empty;
                            for (int i = stringToReverse.Length - 1; i > -1; i--)
                            {
                                reversed += stringToReverse[i];
                            }
                            sb.ToString().IndexOf(stringToReverse);
                            sb.Remove(sb.ToString().IndexOf(stringToReverse), stringToReverse.Length);
                            sb.Append(reversed);
                            Console.WriteLine(sb);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string stringToReplace = currentCommand[1];
                        string stringReplacement = currentCommand[2];
                        while (sb.ToString().Contains(stringToReplace))
                        {
                            sb.Replace(stringToReplace, stringReplacement);
                        }

                        Console.WriteLine(sb);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {sb}");
        }
    }
}
