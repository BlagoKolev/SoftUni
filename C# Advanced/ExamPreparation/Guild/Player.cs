﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string name;
        private string @class;
        private string rank = "Trial";
        private string description = "n/a";

        public Player(string name, string @class)
        {
            this.Name = name;
            this.Class = @class;
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Class
        {
            get { return this.@class; }
            private set { this.@class = value; }
        }

        public string Rank
        {
            get { return this.rank; }
            private set { this.rank = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public void PromoteRank() => this.Rank = "Member";

        public void DemoteRank() => this.Rank = "Trial";
        
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}")
                .AppendLine($"Rank: {this.Rank}")
                .AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
