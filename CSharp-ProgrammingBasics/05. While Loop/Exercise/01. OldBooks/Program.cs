using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            string currentBook = Console.ReadLine();

            int counter = 0;

            while (currentBook != bookName)
            {
                counter += 1;

                if (currentBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");    
                    Console.WriteLine($"You checked {counter-1} books.");
                    break;
                } 

                currentBook = Console.ReadLine();
            }

            if (currentBook == bookName)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
