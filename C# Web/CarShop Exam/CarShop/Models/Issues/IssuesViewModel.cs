using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Issues
{
   public class IssuesViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsItFixed { get; set; }
    }
}
