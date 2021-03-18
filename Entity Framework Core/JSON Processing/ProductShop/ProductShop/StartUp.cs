using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        private static string JsonExportDirectory = "../../../Datasets/Export";

        private static void CheckForExistingExportDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            // ResetAndCreateDatabase(db);


            //PROBLEM - 1
            //string readUsers = File.ReadAllText("../../../Datasets/users.json");
            // Console.WriteLine(ImportUsers(db, readUsers));


            //PROBLEM-2
            //string readProducts = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(db, readProducts));

            //PROBLEM - 3
            //string readCategories = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(db, readCategories));

            //PROBLEM - 4
            //string readCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(db, readCategoryProducts));

            //PROBLEM - 5
            //string jsonOutput = GetProductsInRange(db);
            //CheckForExistingExportDirectory(JsonExportDirectory);
            //File.WriteAllText(JsonExportDirectory + "/products-in-range.json", jsonOutput);


            //PROBLEM - 6
            //string jsonOutput = GetSoldProducts(db);
            //CheckForExistingExportDirectory(JsonExportDirectory);
            //File.WriteAllText(JsonExportDirectory + "/users-sold-products.json", jsonOutput);


            //PROBLEM - 7
            //string jsonString = GetCategoriesByProductsCount(db);
            //CheckForExistingExportDirectory(JsonExportDirectory);
            //File.WriteAllText(JsonExportDirectory + "/categories-by-products.json", jsonString);

            //PROBLEM - 8 
            string jsonString = GetUsersWithProducts(db);
            CheckForExistingExportDirectory(JsonExportDirectory);
            File.WriteAllText(JsonExportDirectory + "/users-and-products.json", jsonString);

        }

        private static void ResetAndCreateDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database 'ProductShop' was successfull deleted");

            context.Database.EnsureCreated();
            Console.WriteLine("Database 'ProductShop' was successfull created");
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoriesProduct = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesProduct);
            context.SaveChanges();

            return $"Successfully imported {categoriesProduct.Length}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToArray();

            string output = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return output;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyerFirstName = p.Buyer.FirstName,
                    buyerLastName = p.Buyer.LastName
                }).ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            var convertToJson = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            return convertToJson;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Count == 0
                    ? 0.ToString("f2") : c.CategoryProducts
                    .Average(x => x.Product.Price)
                    .ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(x => x.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonString;

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts =
                     new
                     {
                         count = u.ProductsSold
                         .Where(p => p.Buyer != null)
                        .Count(),
                         products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                     }
                })
                .OrderByDescending(u => u.soldProducts.products.Count())
                .ToList();

            var resultObj = new
            {
                usersCount = users.Count(),
                users = users
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string jsonOutput = JsonConvert.SerializeObject(resultObj, settings);



            return jsonOutput;
        }
    }
}