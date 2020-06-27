using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        private readonly HashSet<Hero> data;
        public HeroRepository()
        {
            this.data = new HashSet<Hero>();
        }

        public int Count { get { return this.data.Count; } }
        public void Add(Hero hero) => this.data.Add(hero);

        public void Remove(string name) => this.data.RemoveWhere(x => x.Name == name);

        public Hero GetHeroWithHighestStrength() => this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();

        public Hero GetHeroWithHighestAbility() => this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();

        public Hero GetHeroWithHighestIntelligence() => this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

        public override string ToString()
        {
            return (string.Join(Environment.NewLine, this.data));
        }


    }
}
