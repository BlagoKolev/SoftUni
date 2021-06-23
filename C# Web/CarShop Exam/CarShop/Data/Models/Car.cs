using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Issues = new List<Issue>();
        }
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        public int Year { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Issue> Issues { get; set; }

    }
}
