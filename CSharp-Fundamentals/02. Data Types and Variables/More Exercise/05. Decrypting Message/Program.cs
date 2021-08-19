using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numOfSymbols = int.Parse(Console.ReadLine());

            string decryptedMessage = "";

            for (int i = 1; i <= numOfSymbols; i++)
            {
                char input = char.Parse(Console.ReadLine());
                decryptedMessage += (char)((int)input + key);
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
