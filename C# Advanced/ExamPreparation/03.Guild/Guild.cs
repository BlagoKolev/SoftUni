using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private readonly string name;
        private readonly int capacity;
        private readonly List<Player> roster;


        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }


        public int Capacity { get; set; }



        public int Count
        {
            get { return this.roster.Count; }
        }


        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var isPlayerExist = this.roster.Any(x => x.Name == name);
            if (isPlayerExist)
            {
                var playerToRemove = this.roster.Where(x => x.Name == name).FirstOrDefault();
                this.roster.Remove(playerToRemove);
                return isPlayerExist;
            }
            return isPlayerExist;

        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = this.roster.Where(x => x.Name == name).FirstOrDefault();
            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToDemote = this.roster.Where(x => x.Name == name).FirstOrDefault();
            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            var kickedPlayers = this.roster.Where(x => x.Class == playerClass).ToArray();
            this.roster.RemoveAll(x => x.Class == playerClass);
            return kickedPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }

            return sb.ToString().TrimEnd();
        }

    }

}
