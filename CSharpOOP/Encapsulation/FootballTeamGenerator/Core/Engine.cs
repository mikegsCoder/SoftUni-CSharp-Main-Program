using System;
using System.Collections.Generic;
using System.Linq;

using FootballTeamGenerator.Models;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(';');
                string cmdType = cmdArgs[0];

                try
                {
                    List<string> cmdParams = cmdArgs.Skip(1).ToList();

                    if (cmdType == "Team")
                    {
                        this.CreateTeam(cmdParams);
                    }
                    else if (cmdType == "Add")
                    {
                        this.AddPlayerToTeam(cmdParams);
                    }
                    else if (cmdType == "Remove")
                    {
                        this.RemovePlayerFromTeam(cmdParams);
                    }
                    else if (cmdType == "Rating")
                    {
                        this.RateTeam(cmdParams);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
        private void CreateTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];

            Team team = new Team(teamName);

            this.teams.Add(team);
        }
        private void AddPlayerToTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExist(teamName);

            Stats stats = this.BuildStats(cmdArgs.Skip(2).ToArray());

            Player player = new Player(playerName, stats);


            Team team = this.teams.First(t => t.Name == teamName);

            team.AddPlayer(player);
        }
        private void RemovePlayerFromTeam(IList<string> cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExist(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }
        private void RateTeam(IList<string> cmdArgs) 
        {
            string teamName = cmdArgs[0];

            this.ValidateTeamExist(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }
        private Stats BuildStats(string[] statsString)
        {
            int endurance = int.Parse(statsString[0]);
            int sprint = int.Parse(statsString[1]);
            int dribble = int.Parse(statsString[2]);
            int passing = int.Parse(statsString[3]);
            int shooting = int.Parse(statsString[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }
        private void ValidateTeamExist(string teamName)
        {
            //Team team = this.teams.FirstOrDefault(t => t.Name == teamName);
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new InvalidOperationException
                    (String.Format(GlobalConstants.MissingTeamExcMsg, teamName));
            }
        }
    }
}
