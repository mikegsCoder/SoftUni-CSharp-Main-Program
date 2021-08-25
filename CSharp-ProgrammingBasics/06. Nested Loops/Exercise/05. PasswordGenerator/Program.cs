using System;

namespace _05.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i1 = 1; i1 <= n; i1++)
            {
                for (int i2 = 1; i2 <= n; i2++)
                {
                    for (int i3 = 0; i3 <= l-1; i3++)
                    {
                        for (int i4 = 0; i4 <= l-1; i4++)
                        {
                            for (int i5 = Math.Max(i1,i2)+1; i5 <= n; i5++)
                            {
                                Console.Write($"{i1}{i2}{alphabet[i3]}{alphabet[i4]}{i5} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
