using System;

namespace _03.FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirType = Console.ReadLine();
            int souvenirsBought = int.Parse(Console.ReadLine());

            double moneySpent = 0.0;
            bool invalidInfo = false;

            switch (team)
            {
                case "Argentina":
                    if (souvenirType == "flags") moneySpent += 3.25;
                    if (souvenirType == "caps") moneySpent += 7.20;
                    if (souvenirType == "posters") moneySpent += 5.10;
                    if (souvenirType == "stickers") moneySpent += 1.25;
                    if (souvenirType != "stickers" && souvenirType != "posters" && souvenirType != "caps" && souvenirType != "flags")
                    {
                        Console.WriteLine("Invalid stock!");
                        invalidInfo = true;
                    }
                    break;
                case "Brazil":
                    if (souvenirType == "flags") moneySpent += 4.20;
                    if (souvenirType == "caps") moneySpent += 8.50;
                    if (souvenirType == "posters") moneySpent += 5.35;
                    if (souvenirType == "stickers") moneySpent += 1.20;
                    if (souvenirType != "stickers" && souvenirType != "posters" && souvenirType != "caps" && souvenirType != "flags")
                    {
                        Console.WriteLine("Invalid stock!");
                        invalidInfo = true;
                    }
                    break;
                case "Croatia":
                    if (souvenirType == "flags") moneySpent += 2.75;
                    if (souvenirType == "caps") moneySpent += 6.90;
                    if (souvenirType == "posters") moneySpent += 4.95;
                    if (souvenirType == "stickers") moneySpent += 1.10;
                    if (souvenirType != "stickers" && souvenirType != "posters" && souvenirType != "caps" && souvenirType != "flags")
                    {
                        Console.WriteLine("Invalid stock!");
                        invalidInfo = true;
                    }
                    break;
                case "Denmark":
                    if (souvenirType == "flags") moneySpent += 3.10;
                    if (souvenirType == "caps") moneySpent += 6.50;
                    if (souvenirType == "posters") moneySpent += 4.80;
                    if (souvenirType == "stickers") moneySpent += 0.90;
                    if (souvenirType != "stickers" && souvenirType != "posters" && souvenirType != "caps" && souvenirType != "flags")
                    {
                        Console.WriteLine("Invalid stock!");
                        invalidInfo = true;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid country!");
                    invalidInfo = true;
                    break;
            }

            if (!invalidInfo)
            {
                Console.WriteLine($"Pepi bought {souvenirsBought} {souvenirType} of {team} for {moneySpent*souvenirsBought:f2} lv.");
            }
        }
    }
}
