using System;
using System.Linq;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.Append(input);

            while ((command = Console.ReadLine()) != "Done")
            {
                if (command == "TakeOdd")
                {
                    string password = sb.ToString();
                    sb.Clear();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        sb.Append(password[i]);
                    }

                    Console.WriteLine(sb.ToString());
                    continue;
                }
                else
                {
                    string[] currentCommand = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    switch (currentCommand[0])
                    {
                        case "Cut":
                            sb.Remove(int.Parse(currentCommand[1]), int.Parse(currentCommand[2]));
                            Console.WriteLine(sb.ToString());
                            break;

                        case "Substitute":
                            if (sb.ToString().Contains(currentCommand[1]))
                            {
                                while (sb.ToString().Contains(currentCommand[1]))
                                {
                                    sb.Replace(currentCommand[1], currentCommand[2]);
                                }
                                Console.WriteLine(sb.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Nothing to replace!");
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"Your password is: {sb}");
        }
    }
}
