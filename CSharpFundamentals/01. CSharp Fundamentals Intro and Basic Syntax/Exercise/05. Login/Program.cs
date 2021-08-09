using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            string password = "";
            int a = userName.Length - 1;

            while (a >= 0)
            {
                password = password + userName[a];
                a--;
            }

            string input = Console.ReadLine();
            int counter = 0;
            bool blocked = false;

            while (input != password)
            {
                counter++;
                if (counter == 4)
                {
                    blocked = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (blocked)
            {
                Console.WriteLine($"User {userName} blocked! ");
            }
            else
            {
                Console.WriteLine($"User {userName} logged in.");
            }
        }
    }
}
