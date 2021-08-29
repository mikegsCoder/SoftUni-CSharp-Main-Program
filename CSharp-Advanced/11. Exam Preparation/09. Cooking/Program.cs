using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {              
            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquid = liquids.Dequeue();
                int currIngredient = ingredients.Pop();
                int currentSum = currLiquid + currIngredient;

                switch (currentSum)
                {
                    case 25:
                        breadCount++;
                        break;
                    case 50:
                        cakeCount++;
                        break;
                    case 75:
                        pastryCount++;
                        break;
                    case 100:
                        fruitPieCount++;
                        break;
                    default:
                        currIngredient += 3;
                        ingredients.Push(currIngredient);
                        break;
                }
            }
            
            if (breadCount > 0 && cakeCount > 0 && pastryCount > 0 && fruitPieCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine("Liquids left: " + string.Join(", ",liquids));
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine("Ingredients left: " + string.Join(", ",ingredients));
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
