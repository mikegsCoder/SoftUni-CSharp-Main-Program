using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commandElements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandElements[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(commandElements[1]);
                    int endIndex = int.Parse(commandElements[2]);

                    string concatData = string.Empty;

                    if (startIndex < 0 || startIndex > data.Count - 1)
                    {
                        startIndex = 0;
                    }

                    if (endIndex > data.Count - 1 || endIndex < 0)
                    {
                        endIndex = data.Count - 1;
                    }

                    if ((startIndex >= 0 && startIndex <= data.Count - 1)
                        && endIndex >= 0 && endIndex <= data.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            concatData += data[i];
                        }

                        data.RemoveRange(startIndex, endIndex - startIndex + 1);
                        data.Insert(startIndex, concatData);
                    }
                }
                else if (command == "divide")
                {
                    int index = int.Parse(commandElements[1]);
                    int partitions = int.Parse(commandElements[2]);
                    if (index >= 0 && index <= data.Count - 1)
                    {
                        string word = data[index];
                        List<string> dividedWord = new List<string>();
                        int stringLengthToAdd = word.Length / partitions;
                        int startIndex = 0;

                        for (int i = 0; i < partitions; i++)
                        {
                            if (i == partitions - 1)
                            {
                                dividedWord.Add(word.Substring(startIndex, word.Length - startIndex));
                            }
                            else
                            {
                                dividedWord.Add(word.Substring(startIndex, stringLengthToAdd));
                                startIndex += stringLengthToAdd;
                            }
                        }

                        data.RemoveAt(index);
                        data.InsertRange(index, dividedWord);                        
                    }
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine(string.Join(' ', data));
        }
    }
}
