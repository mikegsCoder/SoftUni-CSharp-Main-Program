using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            int currIngredient = 0;
            int currFreshness = 0;

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (true)
            {
                while (currIngredient <= 0 && ingredients.Count > 0)
                {
                    currIngredient = ingredients.Dequeue();
                }

                if (ingredients.Count == 0 && currIngredient == 0)
                {
                    break;
                }

                currFreshness = freshness.Pop();

                int result = currFreshness * currIngredient;

                switch (result)
                {
                    case 150:
                        dippingSauce++;
                        break;
                    case 250:
                        greenSalad++;
                        break;
                    case 300:
                        chocolateCake++;
                        break;
                    case 400:
                        lobster++;
                        break;
                    default:
                        ingredients.Enqueue(currIngredient + 5);
                        break;
                }

                currIngredient = 0;
                currFreshness = 0;

                if (ingredients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }
            }

            if (dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any() && ingredients.Sum() > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if (chocolateCake > 0)
            {
                Console.WriteLine($" # Chocolate cake --> {chocolateCake}");
            }

            if (dippingSauce > 0)
            {
                Console.WriteLine($" # Dipping sauce --> {dippingSauce}");
            }

            if (greenSalad > 0)
            {
                Console.WriteLine($" # Green salad --> {greenSalad}");
            }

            if (lobster > 0)
            {
                Console.WriteLine($" # Lobster --> {lobster}");
            }
        }
    }
}
