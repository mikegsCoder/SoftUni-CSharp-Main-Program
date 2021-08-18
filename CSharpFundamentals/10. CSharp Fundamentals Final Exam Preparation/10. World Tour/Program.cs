using System;
using System.Linq;

namespace _10._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string travelDestinations = Console.ReadLine();
                        
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] currentCommand = input.Split(':').ToArray();

                switch (currentCommand[0])
                {
                    case "Add Stop":
                        int index = int.Parse(currentCommand[1]);

                        if (index >= 0 && index < travelDestinations.Length)
                        {
                            string stopToAdd = currentCommand[2];
                            travelDestinations = travelDestinations.Insert(index, stopToAdd);
                        }                        
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(currentCommand[1]);
                        int endIndex = int.Parse(currentCommand[2]);

                        if (startIndex >= 0 && startIndex < travelDestinations.Length && endIndex >= 0 && endIndex < travelDestinations.Length)
                        {
                            travelDestinations = travelDestinations.Remove(startIndex, endIndex - startIndex + 1);
                        }                        
                        break;
                    case "Switch":
                        string oldString = currentCommand[1];
                        string newString = currentCommand[2];
                        
                        travelDestinations = travelDestinations.Replace(oldString, newString);                        
                        break;
                }

                Console.WriteLine(travelDestinations);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelDestinations}");
        }
    }
}
