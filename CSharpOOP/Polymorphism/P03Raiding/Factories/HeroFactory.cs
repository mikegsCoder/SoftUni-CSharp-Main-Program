using P03Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03Raiding.Factories
{
    public class HeroFactory
    {
        private const string InvalidHero = "Invalid hero!";
        public HeroFactory()
        {

        }

        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else
            {
                throw new InvalidOperationException(InvalidHero);
            }

            return hero;
        }
    }
}
