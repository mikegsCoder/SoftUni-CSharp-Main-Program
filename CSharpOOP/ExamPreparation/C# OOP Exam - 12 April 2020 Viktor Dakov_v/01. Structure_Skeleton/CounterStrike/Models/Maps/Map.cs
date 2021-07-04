using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (IsTeamAlive(counterTerrorists) && IsTeamAlive(terrorists))
            {
                AttackTeam(terrorists, counterTerrorists);
                AttackTeam(counterTerrorists, terrorists);

                if (!IsTeamAlive(counterTerrorists) || !IsTeamAlive(terrorists))
                {
                    break;
                }
            }

            if (!IsTeamAlive(counterTerrorists))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }

        private void AttackTeam(List<IPlayer> attackingTeam, List<IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                //if (!attacker.IsAlive) continue;

                foreach (var defender in defendingTeam)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (IPlayer player in players)
            {
                if (player is CounterTerrorist)
                {
                    counterTerrorists.Add(player);
                }
                else if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
            }
        }
    }
}
