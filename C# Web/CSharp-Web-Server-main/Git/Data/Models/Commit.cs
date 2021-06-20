using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data.Models
{
  public  class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

       
        public string CreatorId { get; set; }
        public User Creator { get; set; }

       
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
