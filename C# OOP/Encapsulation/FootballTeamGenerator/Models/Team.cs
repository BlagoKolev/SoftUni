using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    class Team
    {
        private readonly List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstant.InvalidNameException);
                }
                name = value;
            }
        }

        public void Add(Player player)
        {
           
            this.players.Add(player);
        }

        public void Remove(string playerName)
        {
            if (!this.players.Any(x=>x.Name == playerName))
            {
                throw new ArgumentException(string.Format(GlobalConstant.MissingPlayerException, playerName, this.Name));
            }

            var playerToRemove = this.players.Where(x => x.Name == playerName).FirstOrDefault();
            this.players.Remove(playerToRemove);
        }

        public double Rating(string teamName)
        {
           
            if (this.players.Count ==0)
            {
                return 0;
            }
            var sum = 0.0;
            foreach (var player in this.players)
            {
                sum += player.Stats.SkillLevel;
            }
            return sum / this.players.Count;
        }
    }
}
