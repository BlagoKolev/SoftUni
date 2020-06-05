using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badges = 0;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = badges;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Badges
        {
            get { return this.badges; }
            private set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            private set { this.pokemons = value; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void AddBadge()
        {
            this.Badges++;
        }

        public override string ToString()
        {
            return string.Concat(this.Name + ' ' + this.Badges + ' ' + this.Pokemons.Count);

        }
    }
}
