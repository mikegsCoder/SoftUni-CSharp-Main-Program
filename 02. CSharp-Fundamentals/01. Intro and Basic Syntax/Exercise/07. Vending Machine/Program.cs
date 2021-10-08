using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double money = 0.0;

            while (input != "Start")
            {
                double currentInput = double.Parse(input);
                switch (currentInput)
                {
                    case 0.1:
                        money += 0.1;
                        break;
                    case 0.2:
                        money += 0.2;
                        break;
                    case 0.5:
                        money += 0.5;
                        break;
                    case 1:
                        money += 1;
                        break;
                    case 2:
                        money += 2;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {currentInput}");
                        break;
                }

                input = Console.ReadLine();
            }

            string purchase = Console.ReadLine();

            while (purchase != "End")
            {
                switch (purchase)
                {
                    case "Nuts":
                        if (money >= 2.0)
                        {
                            money -= 2.0;
                            Console.WriteLine($"Purchased nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (money >= 0.7)
                        {
                            money -= 0.7;
                            Console.WriteLine($"Purchased water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (money >= 1.5)
                        {
                            money -= 1.5;
                            Console.WriteLine($"Purchased crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (money >= 0.8)
                        {
                            money -= 0.8;
                            Console.WriteLine($"Purchased soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (money >= 1.0)
                        {
                            money -= 1.0;
                            Console.WriteLine($"Purchased coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }

                purchase = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
