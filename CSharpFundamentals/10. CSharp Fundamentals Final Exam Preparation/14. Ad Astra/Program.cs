using System;
using System.Text.RegularExpressions;

namespace _14.Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|([A-Za-z\s]+)\|([0-9]{2}\/[0-9]{2}\/[0-9]{2})\|([0-9]{1,5})\||\#([A-Za-z\s]+)\#([0-9]{2}\/[0-9]{2}\/[0-9]{2})\#([0-9]{1,5})\#";

            string input = Console.ReadLine();

            var foodMatches = Regex.Matches(input, pattern);

            int caloriesTotal = 0;

            foreach (Match food in foodMatches)
            {
                if (food.Groups[3].Value.Length != 0)
                {
                    caloriesTotal += int.Parse(food.Groups[3].Value);
                }
                else
                {
                    caloriesTotal += int.Parse(food.Groups[6].Value);
                }
            }

            Console.WriteLine($"You have food to last you for: {caloriesTotal / 2000} days!");

            string foodName = string.Empty;
            string date = string.Empty;
            int calories = 0;

            foreach (Match food in foodMatches)
            {
                if (food.Groups[1].Value.Length != 0)
                {
                    foodName = food.Groups[1].Value;
                    date = food.Groups[2].Value;
                    calories = int.Parse(food.Groups[3].Value);
                }
                else
                {
                    foodName = food.Groups[4].Value;                    
                    date = food.Groups[5].Value;
                    calories = int.Parse(food.Groups[6].Value);
                }

                Console.WriteLine($"Item: {foodName}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
