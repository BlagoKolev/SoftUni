using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Data.Models
{
    public class UserCard
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
