using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Import;
using CarDealer.DTO.Export;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CarDealer
{
    public class StartUp
    {
        private static string importDirectory = @"../../../Datasets";
        public static void Main(string[] args)
        {

            using (CarDealerContext db = new CarDealerContext())
            {

                // CreateDatabase(db);

                //PROBLEM - 1 
                //var inputXml = File.ReadAllText("./Datasets/suppliers.xml");
                //Console.WriteLine(ImportSuppliers(db, inputXml));


                //PROBLEM - 2
                //var inputPartXml = File.ReadAllText("./Datasets/parts.xml");
                //Console.WriteLine(ImportParts(db, inputPartXml));


                //PROBLEM - 3
                //var inputCarsXml = File.ReadAllText("./Datasets/cars.xml");
                //Console.WriteLine(ImportCars(db,inputCarsXml));

                //PROBLEM - 4
                //var inputCustomersXml = File.ReadAllText("./Datasets/customers.xml");
                //Console.WriteLine(ImportCustomers(db,inputCustomersXml));

                //PROBLEM - 5
                //var inputSalesXml = File.ReadAllText("./Datasets/sales.xml");
                //Console.WriteLine(ImportSales(db, inputSalesXml));

                //PROBLEM - 6 
                //Console.WriteLine(GetCarsWithDistance(db));

                //PROBLEM - 7
                // Console.WriteLine(GetCarsFromMakeBmw(db));

                //PROBLEM - 8
                //Console.WriteLine(GetLocalSuppliers(db));

                //PROBLEM - 9
                // Console.WriteLine(GetCarsWithTheirListOfParts(db));

                //PROBLEM - 10
                //Console.WriteLine(GetTotalSalesByCustomer(db));

                //PROBLEM - 11
                Console.WriteLine(GetSalesWithAppliedDiscount(db));

            }


        }

        private static void InstanceStaticMapper()
        {

            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ImportSupplierDto, Supplier>();
                x.AddProfile<CarDealerProfile>();

            });

        }

        private static void CreateDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Successfully deleted database: 'CarDealer'");
            db.Database.EnsureCreated();
            Console.WriteLine($"Successfully created database: 'CarDealer' on {DateTime.UtcNow}");

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] serializedSuppliers;

            using (var reader = new StringReader(inputXml))
            {
                serializedSuppliers = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            var suppliers = serializedSuppliers.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.Ismporter
            })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            ImportPartDto[] serializedParts;

            using (var reader = new StringReader(inputXml))
            {
                serializedParts = (ImportPartDto[])xmlSerializer.Deserialize(reader);
            }



            var parts = serializedParts.Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            })
                .Where(x => context.Suppliers.Any(s => s.Id == x.SupplierId))
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var serializedCars = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            var allParts = context.Parts.Select(x => x.Id).ToArray();

            foreach (var car in serializedCars)
            {
                var distinctParts = car.InputCarParts.Select(x => x.Id).Distinct();
                var partCars = distinctParts.Intersect(allParts)
                    .Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToList();

                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance,
                    PartCars = partCars
                };

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var serializedCustomers = (ImportCustomerDto[]
                )xmlSerializer.Deserialize(new StringReader(inputXml));

            Customer[] customers = serializedCustomers.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var serializedSales = (ImportSalesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var carIds = context.Cars.Select(x => x.Id).ToArray();

            Sale[] sales = serializedSales.Select(x => new Sale
            {
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                Discount = x.Discount
            })
                .Where(x => carIds.Contains(x.CarId))
                .ToArray();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();
            var noNameSpaces = new XmlSerializerNamespaces();
            noNameSpaces.Add("", "");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, cars, noNameSpaces);
                result = writer.ToString();
            }
            return result;
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBmwDto[]), new XmlRootAttribute("cars"));

            string result = string.Empty;

            XmlSerializerNamespaces noNameSpases = new XmlSerializerNamespaces();
            noNameSpases.Add("", "");

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, bmwCars, noNameSpases);
                result = writer.ToString();
            }
            return result;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));

            string result = string.Empty;
            XmlSerializerNamespaces noNameSpaces = new XmlSerializerNamespaces();
            noNameSpaces.Add("", "");

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, suppliers, noNameSpaces);
                result = writer.ToString();
            }

            return result;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(x => new ExportCarPartsDto
                    {
                        Name = x.Part.Name,
                        Price = x.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));

            string result = string.Empty;

            XmlSerializerNamespaces noNameSpaces = new XmlSerializerNamespaces();
            noNameSpaces.Add("", "");

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, cars, noNameSpaces);
                result = writer.ToString();
            }

            return result;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                   .Where(c => c.Sales.Any(x => x.CustomerId == c.Id))
                   .Select(c => new CustomerBySalesDto
                   {
                       FullName = c.Name,
                       BoughtCars = c.Sales.Count(),
                       SpentMoney = c.Sales
                       .SelectMany(x => x.Car.PartCars).Sum(c => c.Part.Price)
                   })
                   .OrderByDescending(x => x.SpentMoney)
                   .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerBySalesDto[]), new XmlRootAttribute("customers"));

            XmlSerializerNamespaces noNameSpaces = new XmlSerializerNamespaces();
            noNameSpaces.Add("", "");

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, customers, noNameSpaces);
                result = writer.ToString();
            }

            return result;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SalesWithDiscountDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SalesWithDiscountDto[]), new XmlRootAttribute("sales"));

            XmlSerializerNamespaces noNameSpaces = new XmlSerializerNamespaces();

            noNameSpaces.Add("", "");

            string result = string.Empty;

            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, sales,noNameSpaces);
                result = writer.ToString();
            }

            return result;
        }


    }
}