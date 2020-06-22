using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
       
        
        public Player(string name, string playerClass)
        {
            this.Name = name;
            this.Class = playerClass;
        }
        public string Name { get; set; }
       

        public string Class { get; set; }
       

        public string Rank { get; set; } = "Trial";
       

        public string Description { get; set; } = "n/a";
        
        //public void Promote() => this.Rank = "Member";
       
        //public void Demote() => this.Rank = "Trial";
       
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
