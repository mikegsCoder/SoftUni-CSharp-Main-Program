using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double studentCounter = 0;
            double standardCounter = 0;
            double kidCounter = 0;
            double mainStudentCounter = 0;
            double mainStandardCounter = 0;
            double mainKidCounter = 0;

            while (movieName != "Finish")
            {
                studentCounter = 0;
                standardCounter = 0;
                kidCounter = 0;

                int freePlaces = int.Parse(Console.ReadLine());

                for (int i = 1; i <= freePlaces; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "student") studentCounter++;
                    if (ticketType == "standard") standardCounter++;
                    if (ticketType == "kid") kidCounter++;
                    if (ticketType == "End" || studentCounter+standardCounter+kidCounter == freePlaces)
                    {
                        double percent = ((studentCounter + standardCounter + kidCounter) / freePlaces) * 100;

                        Console.WriteLine($"{movieName} - {percent:f2}% full.");
                        break;
                    }
                }

                movieName = Console.ReadLine();

                mainStudentCounter += studentCounter;
                mainStandardCounter += standardCounter;
                mainKidCounter += kidCounter;
            }

            Console.WriteLine($"Total tickets: {mainStudentCounter + mainStandardCounter + mainKidCounter}");
            Console.WriteLine($"{(mainStudentCounter/(mainStudentCounter + mainStandardCounter + mainKidCounter))*100:f2}% student tickets.");
            Console.WriteLine($"{(mainStandardCounter / (mainStudentCounter + mainStandardCounter + mainKidCounter))*100:f2}% standard tickets.");
            Console.WriteLine($"{(mainKidCounter / (mainStudentCounter + mainStandardCounter + mainKidCounter))*100:f2}% kids tickets.");
        }
    }
}
