using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string nameOfGame = Console.ReadLine();

            bool outOfMoney = false;
            double totalSpent = 0.0;

            while (nameOfGame != "Game Time")
            {
                switch (nameOfGame)
                {
                    case "OutFall 4":
                        if (currentBalance - 39.99 > 0)
                        {
                            currentBalance -= 39.99;
                            totalSpent += 39.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 39.99 == 0)
                        {
                            currentBalance -= 39.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 39.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "CS: OG":
                        if (currentBalance - 15.99 > 0)
                        {
                            currentBalance -= 15.99;
                            totalSpent += 15.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 15.99 == 0)
                        {
                            currentBalance -= 15.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 15.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Zplinter Zell":
                        if (currentBalance - 19.99 > 0)
                        {
                            currentBalance -= 19.99;
                            totalSpent += 19.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 19.99 == 0)
                        {
                            currentBalance -= 19.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 19.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "Honored 2":
                        if (currentBalance - 59.99 > 0)
                        {
                            currentBalance -= 59.99;
                            totalSpent += 59.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 59.99 == 0)
                        {
                            currentBalance -= 59.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 59.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch":
                        if (currentBalance - 29.99 > 0)
                        {
                            currentBalance -= 29.99;
                            totalSpent += 29.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 29.99 == 0)
                        {
                            currentBalance -= 29.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 29.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (currentBalance - 39.99 > 0)
                        {
                            currentBalance -= 39.99;
                            totalSpent += 39.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                        }
                        else if (currentBalance - 39.99 == 0)
                        {
                            currentBalance -= 39.99;
                            Console.WriteLine($"Bought {nameOfGame}");
                            Console.WriteLine("Out of money!");
                            outOfMoney = true;
                            break;
                        }
                        else if (currentBalance - 39.99 < 0)
                        {
                            Console.WriteLine("Too Expensive");
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                nameOfGame = Console.ReadLine();
            }

            if (!outOfMoney)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
