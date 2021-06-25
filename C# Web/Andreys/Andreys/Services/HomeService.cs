using Andreys.Data;
using Andreys.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public class HomeService : IHomeService
    {
        private readonly AppDbContext db;
        public HomeService(AppDbContext db)
        {
            this.db = db;
        }
        public ICollection<HomeViewModel> GetAllProducts()
        {
            var products = this.db.Products
                .Select(x => new HomeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price
                })
                .ToList();
            return products;
        }
    }
}
