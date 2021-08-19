using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> daemons = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            daemons.Sort();

            List<int> health = new List<int>();
            List<double> damage = new List<double>();

            for (int j = 0; j < daemons.Count; j++)
            {
                int currentDaemonHealth = 0;
                double currentDaemonDamage = 0.0;

                var healthMatches = Regex.Matches(daemons[j], @"[^+\-*\/\.0-9]");
                var damageMatches = Regex.Matches(daemons[j], @"[-+]?[0-9]+(?:\.\d+)?");
                var damageMathOperations = Regex.Matches(daemons[j], @"\*{1}|\/{1}");

                foreach (Match healthString in healthMatches)
                {
                    for (int i = 0; i < healthString.Value.Length; i++)
                    {
                        currentDaemonHealth += (int)healthString.Value[i];
                    }
                }

                health.Add(currentDaemonHealth);

                foreach (Match damageString in damageMatches)
                {
                    currentDaemonDamage += double.Parse(damageString.Value);
                }

                foreach (Match damageMathString in damageMathOperations)
                {
                    if (damageMathString.Value == "*")
                    {
                        currentDaemonDamage *= 2;
                    }
                    else
                    {
                        currentDaemonDamage /= 2;
                    }
                }

                damage.Add(currentDaemonDamage);
            }
                        
            for (int i = 0; i < daemons.Count; i++)
            {
                Console.WriteLine($"{daemons[i]} - {health[i]} health, {damage[i]:f2} damage");
            }
        }
    }
}
