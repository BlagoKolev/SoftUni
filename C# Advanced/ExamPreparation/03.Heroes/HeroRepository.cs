using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private readonly List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();

        }
        public int Count
        {
            get { return this.heroes.Count; }
        }

        public void Add(Hero hero)
        {
            var isHeroExist = this.heroes.Any(x => x.Name == hero.Name);
            if (!isHeroExist)
            {
                this.heroes.Add(hero);
            }

        }

        public void Remove(string name)
        {
            var heroToRemove = this.heroes.Where(x => x.Name == name).FirstOrDefault();
            this.heroes.Remove(heroToRemove);
        }

        public Hero GetHeroWithHighestStrength()
        {
            var heroWithHighestStrength = this.heroes.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
            return heroWithHighestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var heroWithHighesstAbility = this.heroes.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
            return heroWithHighesstAbility;

        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var heroWithHighestIntelligence = this.heroes.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

            return heroWithHighestIntelligence;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
