using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CarDealer.DTO;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        private static string readDirectory = "../../../Datasets";
        private static string exportDirectory = "../../../Export";
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();

            // CreateDatabase(db);

            //////PROBLEM - 1
            //string jsonSupplier = File.ReadAllText(readDirectory + "/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, jsonSupplier));


            //////PROBLEM - 2
            //string jsonParts = File.ReadAllText(readDirectory + "/parts.json");
            //Console.WriteLine(ImportParts(db, jsonParts));


            //////PROBLEM - 3
            //string jsonCars = File.ReadAllText(readDirectory + "/cars.json");
            //Console.WriteLine(ImportCars(db, jsonCars));


            ////PROBLEM - 4
            //string jsonCustomer = File.ReadAllText(readDirectory + "/customers.json");
            //Console.WriteLine(ImportCustomers(db, jsonCustomer));

            ////PROBLEM - 5
            //string jsonSales = File.ReadAllText(readDirectory + "/sales.json");
            //Console.WriteLine(ImportSales(db, jsonSales));



            //-------------------------------------------------------------------
            //Query and Export Data

            //PROBLEM - 6 Export Ordered Customers
            //if (!Directory.Exists(exportDirectory))
            //{
            //    CreateExportDirectory(exportDirectory);
            //}
            //var orderedCustomer = GetOrderedCustomers(db);
            //WriteToFile(exportDirectory + "/ordered-customers.json", orderedCustomer);


            //PROBLEM - 7 
            //if (!Directory.Exists(exportDirectory))
            //{
            //    CreateExportDirectory(exportDirectory);
            //}
            //var carsFromMakeToyota = GetCarsFromMakeToyota(db);
            //WriteToFile(exportDirectory + "/toyota-cars.json", carsFromMakeToyota);


            //PROBLEM - 8
            //if (!Directory.Exists(exportDirectory))
            //{
            //    CreateExportDirectory(exportDirectory);
            //}
            //var suppliers = GetLocalSuppliers(db);
            //File.WriteAllText(exportDirectory + "/local-suppliers.json", suppliers);


            ////PROBLEM - 9
            //if (!Directory.Exists(exportDirectory))
            //{
            //    Directory.CreateDirectory(exportDirectory);
            //}
            //string carsAndParts = GetCarsWithTheirListOfParts(db);
            //File.WriteAllText(exportDirectory + "/cars-and-parts.json", carsAndParts);


            //PROBLEM - 10
            //if (!Directory.Exists(exportDirectory))
            //{
            //    Directory.CreateDirectory(exportDirectory);
            //}
            //string totalSalesByCustomer = GetTotalSalesByCustomer(db);
            //File.WriteAllText(exportDirectory + "/customers-total-sales.json", totalSalesByCustomer);


            //PROBLEM - 11
            if (!Directory.Exists(exportDirectory))
            {
                Directory.CreateDirectory(exportDirectory);
            }
            string salesWithdiscount = GetSalesWithAppliedDiscount(db);
            File.WriteAllText(exportDirectory + "/sales-discounts.json", salesWithdiscount);


        }
        private static void CreateDatabase(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }
        private static void CreateExportDirectory(string path)
        {
            Directory.CreateDirectory(exportDirectory);
        }
        private static void WriteToFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersToInsert = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = suppliersToInsert.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsDeserialize = JsonConvert.DeserializeObject<IEnumerable<ImportPartsInputModel>>(inputJson);

            var suppliers = context.Suppliers.Select(x => x.Id).ToList();

            var partsToImport = partsDeserialize.Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            })
                .Where(x => suppliers.Contains(x.SupplierId))
                .ToList();



            context.Parts.AddRange(partsToImport);
            context.SaveChanges();

            return $"Successfully imported {partsToImport.Count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var deserializeCars = JsonConvert.DeserializeObject<IEnumerable<ImportCarsModel>>(inputJson);

            var carList = new List<Car>();

            foreach (var car in deserializeCars)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }
                carList.Add(currentCar);
            }

            context.Cars.AddRange(carList);
            context.SaveChanges();
            return $"Successfully imported {carList.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var deserializedCustomers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson).ToArray();

            context.Customers.AddRange(deserializedCustomers);
            context.SaveChanges();

            return $"Successfully imported {deserializedCustomers.Length}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var serializedSales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson).ToArray();

            context.Sales.AddRange(serializedSales);
            context.SaveChanges();

            return $"Successfully imported {serializedSales.Length}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Culture = CultureInfo.InvariantCulture,
                Formatting = Formatting.Indented
            };

            var jsonCustomers = JsonConvert.SerializeObject(customers, settings);

            return jsonCustomers;

        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            string serializedCars = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return serializedCars;
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {

            var localSupplier = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .OrderBy(s => s.Id)
                .ToArray();

            var serialisedSupplier = JsonConvert.SerializeObject(localSupplier, Formatting.Indented);

            return serialisedSupplier;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f"),
                    }).ToArray()
                })

                .ToList();

            var serializedCarsAndParts = JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);

            return serializedCarsAndParts;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context
                .Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var serializedTotalSales = JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);

            return serializedTotalSales;
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2").TrimEnd(),
                    price = s.Car.PartCars.Sum(x => x.Part.Price).ToString("f2").TrimEnd(),
                    priceWithDiscount = (s.Car.PartCars.Sum(x => x.Part.Price) - s.Discount / 100 * s.Car.PartCars.Sum(x => x.Part.Price)).ToString("f2").TrimEnd()
                })
                .Take(10)
                .ToList();

            var serizlizedSales = JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);

            return serizlizedSales;
        }

    }
}
