using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal slary) 
            : base(id, firstName,lastName)
        {
            this.Salary = slary;
        }

        public decimal Salary { get; }
    }
}
