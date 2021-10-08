using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}
