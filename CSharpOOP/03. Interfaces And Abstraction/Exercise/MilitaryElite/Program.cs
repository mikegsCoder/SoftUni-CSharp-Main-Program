using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICollection<ISoldier> solders = new List<ISoldier>();

            string command;
            Soldier soldier;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();
                string solderType = commandArgs[0];

                switch (solderType)
                {
                    case "Private":
                        int privateId = int.Parse(commandArgs[1]);
                        string privateFirstName = commandArgs[2];
                        string privateLastName = commandArgs[3];
                        decimal privateSalary = decimal.Parse(commandArgs[4]);

                        soldier = new Private(
                            privateId,
                            privateFirstName,
                            privateLastName,
                            privateSalary);

                        solders.Add(soldier);
                        break;
                    case "LeutenantGeneral":
                        int leutenentId = int.Parse(commandArgs[1]);
                        string leutenentFirstName = commandArgs[2];
                        string leutenentLastName = commandArgs[3];
                        decimal leutenentSalary = decimal.Parse(commandArgs[4]);

                        ICollection<IPrivate> lieutenantPrivates = new List<IPrivate>();

                        for (int i = 5; i < commandArgs.Length; i++)
                        {
                            int currentID = int.Parse(commandArgs[i]);

                            foreach (var solder in solders)
                            {
                                if (solder.Id == currentID)
                                {
                                    lieutenantPrivates.Add((IPrivate)solder);
                                }
                            }
                        }

                        soldier = new LieutenantGeneral(leutenentId, leutenentFirstName, leutenentLastName, leutenentSalary, lieutenantPrivates);

                        solders.Add(soldier);
                        break;
                    case "Engineer":
                        int engineerId = int.Parse(commandArgs[1]);
                        string engineerFirstName = commandArgs[2];
                        string engineerLastName = commandArgs[3];
                        decimal engineerSalary = decimal.Parse(commandArgs[4]);

                        break;
                    case "Commando":
                        break;
                    case "Spy":
                        break;
                }
            }

            foreach (var solder in solders)
            {
                Console.WriteLine(solder);
            }
        }
    }
}
