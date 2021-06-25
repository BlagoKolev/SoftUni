using Andreys.Data;
using Andreys.Data.Models;
using Andreys.Models.Products;
using BattleCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext db;
        public ProductService(AppDbContext db)
        {
            this.db = db;
        }
        public bool AddProduct(AddProductsFormModel model)
        {
            var isAddSuccessful = false;

            Category category;
            Gender gender;
                        
            var TryParseCategory = Enum.TryParse<Category>(model.Category, out category);
            var TryParseGender = Enum.TryParse<Gender>(model.Gender, out gender);
            if (TryParseCategory && TryParseGender)
            {

                var newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    Category = category,
                    Gender = gender
                };
                this.db.Products.Add(newProduct);
                db.SaveChanges();
                isAddSuccessful = true;
            }
            return isAddSuccessful;
        }

        public void DeleteProduct(int productId)
        {
            var product = this.db.Products
                .Where(p => p.Id == productId)
                .FirstOrDefault();

            this.db.Remove(product);
            this.db.SaveChanges();
        }

        public ProductDetailsViewModel GetDetails(int id)
        {
            var product = this.db.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Gender = x.Gender.ToString(),
                    Category = x.Category.ToString(),
                    Price = x.Price,
                    ImageUrl = x.ImageUrl
                })
                .FirstOrDefault();

            return product;
        }
    }
}
