using System;
using System.Linq;
using System.Text;

namespace _07.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(key);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] currentCommand = command
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentCommand[0])
                {
                    case "Contains":
                        string substring = currentCommand[1];
                        if (sb.ToString().Contains(substring))
                        {
                            Console.WriteLine($"{sb} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string flipCommand = currentCommand[1];
                        int startIndex = int.Parse(currentCommand[2]);
                        int stopIndex = int.Parse(currentCommand[3]);
                        if (flipCommand == "Upper")
                        {
                            string toUpper = sb.ToString().Substring(startIndex, stopIndex - startIndex).ToUpper();
                            sb.Remove(startIndex, stopIndex - startIndex);
                            sb.Insert(startIndex, toUpper);
                        }
                        else
                        {
                            string toLower = sb.ToString().Substring(startIndex, stopIndex - startIndex).ToLower();
                            sb.Remove(startIndex, stopIndex - startIndex);
                            sb.Insert(startIndex, toLower);
                        }
                        Console.WriteLine(sb);
                        break;
                    case "Slice":
                        int startingIndex = int.Parse(currentCommand[1]);
                        int endingIndex = int.Parse(currentCommand[2]);
                        sb.Remove(startingIndex, endingIndex - startingIndex);
                        Console.WriteLine(sb);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {sb}");
        }
    }
}
