using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}
