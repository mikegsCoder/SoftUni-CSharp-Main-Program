using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTeam = int.Parse(Console.ReadLine());
            List<Team> teams = CreatTeams(countTeam);
            DisplayTeams(teams);
        }

        private static List<Team> CreatTeams(int num)
        {
            List<Team> teams = new List<Team>();
            for (int i = 0; i < num; i++)
            {
                Team newTeam = new Team();
                
                string[] line = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string creator = line[0];
                string team = line[1];
                if (!teams.Select(team => team.TeamName).Contains(team))
                {
                    if (!teams.Select(team => team.Creator).Contains(creator))
                    {
                        newTeam.Add(creator, team);
                        teams.Add(newTeam);
                        Console.WriteLine($"Team {team} has been created by {creator}!");
                    }
                    else Console.WriteLine($"{creator} cannot create another team!");
                }
                else Console.WriteLine($"Team {team} was already created!");
            }

            teams = CreateMembers(teams).ToList();
            return teams;
        }

        private static List<Team> CreateMembers(List<Team> teams)
        {
            Team newMember = new Team();
            string line = string.Empty;
            while ((line = Console.ReadLine()) != "end of assignment")
            {
                string[] newLine = line.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string member = newLine[0];
                string team = newLine[1];

                if (!teams.Select(team => team.TeamName).Contains(team))
                    Console.WriteLine($"Team {team} does not exist!");
                else if (teams.Select(team => team.Creator).Contains(member) ||
                        teams.Select(team => team.Member).Any(m => m.Contains(member)))
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                else
                {
                    int creatorIndex = teams.FindIndex(i => i.TeamName == team);
                    teams[creatorIndex].Member.Add(member);
                }
            }

            return teams;
        }
        static void DisplayTeams(List<Team> teams)
        {
            var disbandList = teams.OrderBy(x => x.TeamName).Where(x => x.Member.Count == 0);

            teams = teams.OrderByDescending(x => x.Member.Count)
                .ThenBy(x => x.TeamName)
                .Where(x => x.Member.Count > 0)
                .ToList();
            
            foreach (var team in teams.Where(t => t.Member.Count > 0))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Member.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var member in disbandList)
            {
                Console.WriteLine($"{member.TeamName}");
            }
        }
    }
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Member { get; set; } = new List<string>();
        public void Add(string user, string team)
        {
            this.TeamName = team;
            this.Creator = user;
        }
    }
}