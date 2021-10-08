using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (!PasswordCharactersCounter(input))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!PasswordConsistenceOfLettersAndDigits(input))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!PasswordHaveTwoDigits(input))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (PasswordCharactersCounter(input)
                && PasswordConsistenceOfLettersAndDigits(input)
                && PasswordHaveTwoDigits(input))
            {
                Console.WriteLine("Password is valid");
            }

        }
        static bool PasswordCharactersCounter(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool PasswordConsistenceOfLettersAndDigits(string password)
        {
            bool isLettersAndDigits = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (((int)password[i] >= 65 && (int)password[i] <= 90) ||
                    ((int)password[i] >= 97 && (int)password[i] <= 122) ||
                    ((int)password[i] >= 48 && (int)password[i] <= 57))
                {
                    continue;
                }
                else
                {
                    isLettersAndDigits = false;
                    break;
                }
            }
            
            return isLettersAndDigits;
        }

        static bool PasswordHaveTwoDigits(string password)
        {
            int digitCounter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((int)password[i] >= 48 && (int)password[i] <= 57)
                {
                    digitCounter++;
                }
            }

            if (digitCounter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
