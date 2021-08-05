using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal slary, SoldierCorpEnum soldierCorpEnum) 
            : base(id, firstName, lastName, slary)
        {
            this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }
    }
}
