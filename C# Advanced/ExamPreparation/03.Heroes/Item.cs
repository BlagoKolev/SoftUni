using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public Item(int strength, int ability, int inteligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = inteligence;
        }

        public int Strength
        {
            get { return this.strength; }
            set { this.strength = value; }
        }

        public int Ability
        {
            get { return this.ability; }
            set { this.ability = value; }
        }


        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Item:")
                .AppendLine(string.Format("  *  Strength: {0}", this.Strength))
                .AppendLine(string.Format("  *  Ability: {0}", this.Ability))
                .AppendLine(string.Format("  *  Intelligence: {0}", this.Intelligence));

            return sb.ToString().TrimEnd();
        }
    }
}
