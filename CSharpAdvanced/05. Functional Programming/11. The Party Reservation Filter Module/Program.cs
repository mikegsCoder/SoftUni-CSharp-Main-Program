using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int[] filter = new int[names.Count];

            string input = string.Empty;

            Func<string, string, bool> startWithPredicate = (name, substr) =>
            {
                return name.Substring(0, substr.Length) == substr;
            };

            Func<string, string, bool> endWithPredicate = (name, substr) =>
            {
                return name.Substring(name.Length - substr.Length) == substr;
            };

            Func<string, string, bool> containsPredicate = (name, substr) =>
            {
                return name.Contains(substr);
            };

            Func<string, int, bool> nameLengthPredicate = (name, lenght) =>
            {
                return name.Length == lenght;
            };

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] currentCommand = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                
                string substr = currentCommand[2];

                switch (currentCommand[0])
                {
                    case "Add filter":

                        if (currentCommand[1] == "Starts with")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (startWithPredicate(names[i], substr))
                                {
                                    filter[i]--;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Ends with")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (endWithPredicate(names[i], substr))
                                {
                                    filter[i]--;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Contains")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (containsPredicate(names[i], substr))
                                {
                                    filter[i]--;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Length")
                        {
                            int lenght = int.Parse(substr);

                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (nameLengthPredicate(names[i], lenght))
                                {
                                    filter[i]--;
                                }
                            }
                        }
                        break;
                    case "Remove filter":

                        if (currentCommand[1] == "Starts with")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (startWithPredicate(names[i], substr))
                                {
                                    filter[i]++;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Ends with")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (endWithPredicate(names[i], substr))
                                {
                                    filter[i]++;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Contains")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (containsPredicate(names[i], substr))
                                {
                                    filter[i]++;
                                }
                            }
                        }
                        else if (currentCommand[1] == "Length")
                        {
                            int lenght = int.Parse(substr);

                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (nameLengthPredicate(names[i], lenght))
                                {
                                    filter[i]++;
                                }
                            }
                        }
                        break;
                }
            }

            for (int i = 0; i < names.Count; i++)
            {
                if (filter[i] >= 0)
                {
                Console.Write(names[i] + " ");

                }
            } 
        }
    }
}
