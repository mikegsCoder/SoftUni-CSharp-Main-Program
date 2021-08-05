using System.Collections.Generic;

using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal slary, ICollection<IPrivate> privates) 
            : base(id, firstName, lastName, slary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }
    }
}
