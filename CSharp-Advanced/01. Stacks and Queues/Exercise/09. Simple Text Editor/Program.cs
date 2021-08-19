using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> commands = new Stack<string>();

            StringBuilder sb = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] currentInput = input.Split().ToArray();

                switch (currentInput[0])
                {
                    case "1":
                        sb.Append(currentInput[1]);
                        commands.Push($"{currentInput[0]} {currentInput[1].Length}");
                        break;
                    case "2":
                        int countToRemove = int.Parse(currentInput[1]);
                        string stringToRemove = sb.ToString().Substring(sb.Length - countToRemove);
                        sb.Remove(sb.Length - countToRemove, countToRemove); 
                        commands.Push($"{currentInput[0]} {stringToRemove}");
                        break;
                    case "3":
                        int indexPosition = int.Parse(currentInput[1]);
                        Console.WriteLine(sb[indexPosition-1]);
                        break;
                    case "4":
                        string[] commandToUndo = commands.Pop().Split().ToArray();

                        switch (commandToUndo[0])
                        {
                            case "1":
                                int lengthToRemove = int.Parse(commandToUndo[1]);
                                sb.Remove(sb.Length - lengthToRemove, lengthToRemove);
                                break;
                            case "2":
                                sb.Append(commandToUndo[1]);                                
                                break;
                        }
                        break;
                }
            }            
        }
    }
}
