using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace ConsoleApp5
{
    static class Program
    {

        public static void Main(string[] args)
        {
            string[] tickets = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            foreach (var ticket in tickets)
            {

                if (ticket.Length == 20)
                {
                    string pattern = @"\@{6,}|\#{6,}|\${6,}|\^{6,}";
                    StringBuilder sbLeft = new StringBuilder();
                    StringBuilder sbRight = new StringBuilder();
                    var halfLeft = ticket.Take(10).ToArray();
                    var halfRight = ticket.Skip(10).Take(10).ToArray();

                    for (int i = 0; i < 10; i++)
                    {
                        sbLeft.Append(halfLeft[i]);
                        sbRight.Append(halfRight[i]);
                    }

                    Match matchLeft = Regex.Match(sbLeft.ToString(), pattern);
                    Match matchRight = Regex.Match(sbRight.ToString(), pattern);

                    if (matchLeft.Success && matchRight.Success)
                    {
                        int matchLength = Math.Min(matchLeft.Length, matchRight.Length);
                        string matchL = matchLeft.ToString().Substring(0, matchLength);
                        string matchR = matchRight.ToString().Substring(0, matchLength);

                        if (matchL.Equals(matchR))
                        {
                            char symbol = matchL[0];

                            if (matchLength == 10)
                            {
                                Console.WriteLine(($"ticket \"{ticket}\" - {matchLength}{symbol} Jackpot!"));

                            }
                            else
                            {
                                Console.WriteLine(($"ticket \"{ticket}\" - {matchLength}{symbol}"));

                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}