using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Issues
{
    public class CarIssuesViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public ICollection<IssuesViewModel> Issues { get; set; }
    }
}
