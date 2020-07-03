using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;


        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstant.InvalidNameException);
                }
                this.name = value;
            }
        }

        public Stats Stats { get; private set; }


    }
}
