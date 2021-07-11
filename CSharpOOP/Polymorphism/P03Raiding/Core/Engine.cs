using System;
using System.Collections.Generic;
using System.Text;
using P03Raiding.Factories;
using P03Raiding.Models;

namespace P03Raiding.Core
{
    public class Engine
    {
        private HeroFactory heroFactory;
        private ICollection<BaseHero> raidGroup;
        public Engine()
        {
            this.heroFactory = new HeroFactory();
            this.raidGroup = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int validHeroes = 0;

            while(validHeroes < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    BaseHero hero = heroFactory.CreateHero(name, type);

                    raidGroup.Add(hero);
                    validHeroes++;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            
            int bossPower = int.Parse(Console.ReadLine());

            int raidGroupPower = 0;

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                raidGroupPower += hero.Power;
            }

            if (raidGroupPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
