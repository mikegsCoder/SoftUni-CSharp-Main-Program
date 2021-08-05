using System.Collections.Generic;
using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal slary, SoldierCorpEnum soldierCorpEnum, ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, slary, soldierCorpEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }
    }
}
