namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int CivilPlayerInitialLifePoints = 50;

        public CivilPlayer(string name) 
            : base(name, CivilPlayerInitialLifePoints)
        {
        }
    }
}
