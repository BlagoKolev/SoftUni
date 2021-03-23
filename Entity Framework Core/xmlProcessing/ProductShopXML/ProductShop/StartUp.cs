using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        private static string importDirectory = "../../../Datasets";

        public static void Main(string[] args)
        {
            //Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            ProductShopContext db = new ProductShopContext();
            // CreateDatabase(db);

            //PROBLEM - 1
            //var readUsers = File.ReadAllText(importDirectory + "/users.xml");
            //Console.WriteLine(ImportUsers(db, readUsers));


            //PROBLEM - 2
            //var inputXml = File.ReadAllText("./Datasets/products.xml");
            //Console.WriteLine(ImportProducts(db,inputXml));


            //PROBLEM - 3
            //var importCategoriesXml = File.ReadAllText("./Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(db, importCategoriesXml));

            //PROBLEM - 4
            //var importCategoriesProductsXml = File.ReadAllText("./Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(db, importCategoriesProductsXml));


            //PROBLEM - 5
            //Console.WriteLine(GetProductsInRange(db));

            //PROBLEM - 6
            // Console.WriteLine(GetSoldProducts(db));


            //PROBLEM - 7
            //Console.WriteLine(GetCategoriesByProductsCount(db));


            //PROBLEM - 8
            Console.WriteLine(GetUsersWithProducts(db));

        }

        private static void CreateDatabase(DbContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Successfully Deleted");
            db.Database.EnsureCreated();
            Console.WriteLine("Database successfully created on: " + DateTime.UtcNow);

        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var users = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedUsers = Mapper.Map<User[]>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();



            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            ImportProductDto[] serializedProducts;

            using (var reader = new StringReader(inputXml))
            {
                serializedProducts = (ImportProductDto[])serializer.Deserialize(reader);
            }

            var products = serializedProducts.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                BuyerId = x.BuyerId,
                SellerId = x.SellerId
            })
                 .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer seriazlizer = new XmlSerializer(typeof(ImportCategoriesDto[]), new XmlRootAttribute("Categories"));

            ImportCategoriesDto[] serializedCategories;

            using (var reader = new StringReader(inputXml))
            {
                serializedCategories = (ImportCategoriesDto[])seriazlizer.Deserialize(reader);
            }

            var categories = serializedCategories
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));


            CategoryProductDto[] seriaizedCategoryProducts;

            using (var reader = new StringReader(inputXml))
            {
                seriaizedCategoryProducts = (CategoryProductDto[])serializer.Deserialize(reader);
            }

            var productsIds = context.Products.Select(x => x.Id);
            var categoriesIds = context.Categories.Select(x => x.Id);

            var categoryProducts = seriaizedCategoryProducts
                .Where(x => productsIds.Contains(x.ProductId) && categoriesIds.Contains(x.CategoryId))
                .Select(x => new CategoryProduct
                {
                    ProductId = x.ProductId,
                    CategoryId = x.CategoryId
                })
                .ToArray();

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var result = string.Empty;

            XmlSerializerNamespaces noNameSpace = new XmlSerializerNamespaces();

            noNameSpace.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, products, noNameSpace);
                result = writer.ToString();
            }
            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count() > 0)
                .Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(x => new ProductDto
                    {
                        Name = x.Name,
                        Price = x.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));

            string result = string.Empty;

            XmlSerializerNamespaces noNameSpace = new XmlSerializerNamespaces();
            noNameSpace.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, users, noNameSpace);
                result = writer.ToString();
            }
            return result;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            string result = string.Empty;

            XmlSerializerNamespaces noNameSpace = new XmlSerializerNamespaces();
            noNameSpace.Add("", "");

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, categories, noNameSpace);
                result = writer.ToString();
            }
            return result;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
               .OrderByDescending(u => u.ProductsSold.Count)
               .Take(10)
                .Select(u => new UserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold.Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Price = x.Price
                        })
                       .OrderByDescending(x => x.Price)
                       .ToArray()
                    }
                })
                 .ToArray();


            var usersAndProducts = new UserAndProductsDto
            {
                Count =context.Users.Count(x=>x.ProductsSold.Any()),
                Users = users
            };


            XmlSerializer serializer = new XmlSerializer(typeof(UserAndProductsDto), new XmlRootAttribute("Users"));

            XmlSerializerNamespaces noNameSpace = new XmlSerializerNamespaces();
            noNameSpace.Add("", "");

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, usersAndProducts, noNameSpace);
                result = writer.ToString();
            }
            return result;
        }
    }
}