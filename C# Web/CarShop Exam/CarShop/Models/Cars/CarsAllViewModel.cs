using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Models.Cars
{
    public class CarsAllViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public int FixedIssues { get; set; }
        public int RemainingIssues { get; set; }
        public string PictureUrl { get; set; }
    }
}
