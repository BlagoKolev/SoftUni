﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Issue
    {
        public Issue()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsFixed { get; set; }
        [Required]
        public string CarId { get; set; }
        public Car Car { get; set; }
    }
}
