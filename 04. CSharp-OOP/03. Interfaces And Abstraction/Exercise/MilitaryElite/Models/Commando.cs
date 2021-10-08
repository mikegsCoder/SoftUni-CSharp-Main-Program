using System.Collections.Generic;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal slary, SoldierCorpEnum soldierCorpEnum, ICollection<IMission> missions) 
            : base(id, firstName, lastName, slary, soldierCorpEnum)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }
    }
}
