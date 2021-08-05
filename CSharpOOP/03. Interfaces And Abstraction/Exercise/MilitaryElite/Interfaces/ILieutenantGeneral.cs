using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}
