using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
   public  class Department
    {
        public Department()
        {
            this.Cells = new HashSet<Cell>();
            this.Officers = new HashSet<Officer>();
        }


        [Key]
        public int   Id { get; set; }

        [Required]
        [StringLength(25,MinimumLength =3)]
        public string Name { get; set; }


        public virtual ICollection<Cell> Cells { get; set; }
        public virtual ICollection<Officer> Officers { get; set; }
    }
}
