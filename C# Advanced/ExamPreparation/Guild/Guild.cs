using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        private string name;
        private int capacity;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Count { get { return this.roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isPlayerExist = this.roster.Where(x => x.Name == name).Any();
            if (isPlayerExist)
            {
                var playerToRemove = this.roster.Where(x => x.Name == name).FirstOrDefault();
                this.roster.Remove(playerToRemove);
            }
            return isPlayerExist;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = this.roster.Where(x => x.Name == name).FirstOrDefault();
            if (playerToPromote.Rank == "Trial")
            {
                playerToPromote.PromoteRank();
            }
        }
        public void DemotePlayer(string name)
        {
            var playerToDemote = this.roster.Where(x => x.Name == name).FirstOrDefault();
            if (playerToDemote.Rank=="Member")
            {
                playerToDemote.DemoteRank();
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var kickedPlayers = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == @class)
                {
                    kickedPlayers.Add(player);
                }
            }
            this.roster.RemoveAll(x => x.Class == @class);
            return kickedPlayers.ToArray();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }
        
    }
}
