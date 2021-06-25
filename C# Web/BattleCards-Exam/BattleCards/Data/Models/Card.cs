using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Data.Models
{
    public class Card
    {
        public Card()
        {
            this.UserCards = new HashSet<UserCard>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<UserCard> UserCards { get; set; }
    }
}
