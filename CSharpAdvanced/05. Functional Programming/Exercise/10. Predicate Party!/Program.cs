using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = string.Empty;

            Func<string, string, bool> startWithPredicate = (name, substr) =>
            {
                return name.Substring(0, substr.Length) == substr;
            };

            Func<string, string, bool> endWithPredicate = (name, substr) =>
            {
                return name.Substring(name.Length - substr.Length) == substr;
            };

            Func<string, int, bool> nameLengthPredicate = (name, lenght) =>
            {
                return name.Length == lenght;
            };

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] currentCommand = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string substr = currentCommand[2];

                switch (currentCommand[0])
                {
                    case "Remove":

                        if (currentCommand[1] == "StartsWith")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (startWithPredicate(names[i], substr))
                                {
                                    names.Remove(names[i]);
                                }
                            }
                        }
                        else if (currentCommand[1] == "EndsWith")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (endWithPredicate(names[i], substr))
                                {
                                    names.Remove(names[i]);
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
                                    names.Remove(names[i]);
                                }
                            }
                        }
                        break;
                    case "Double":

                        if (currentCommand[1] == "StartsWith")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (startWithPredicate(names[i], substr))
                                {
                                    names.Insert(i + 1, names[i]);
                                }
                            }
                        }
                        else if (currentCommand[1] == "EndsWith")
                        {
                            for (int i = names.Count - 1; i >= 0; i--)
                            {
                                if (endWithPredicate(names[i], substr))
                                {
                                    names.Insert(i + 1, names[i]);
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
                                    names.Insert(i + 1, names[i]);
                                }
                            }
                        }
                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.Write(string.Join(", ", names));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
