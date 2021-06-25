using BattleCards.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Users = new List<User>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
