using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Models;

namespace ShoppingSpree.Core
{
   public class Engine
    {
        private List<Product> products;
        private List<Person> persons;

        public Engine()
        {
            this.products = new List<Product>();
            this.persons = new List<Person>();
        }

        public void Run()
        {
            AddPerson();
            AddProduct();

            while (true)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }
                var personName = command[0];
                var productName = command[1];
                try
                {
                    var currentPerson = this.persons.FirstOrDefault(p => p.Name == personName);
                    var currentProduct = this.products.FirstOrDefault(p => p.Name == productName);

                    currentPerson.BuyProduct(currentProduct);
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}" );
                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }
               
            }

            PrintOutput();
        }
        private void AddPerson()
        {
            var personsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personsArgs.Length; i++)
            {
                var currentPerson = personsArgs[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                var personName = currentPerson[0];
                var money = decimal.Parse(currentPerson[1]);

                var person = new Person(personName, money);
                this.persons.Add(person);
            }
        }

        private void AddProduct()
        {
            var productArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productArgs.Length; i++)
            {
                var currentProduct = productArgs[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                var productName = currentProduct[0];
                var cost = decimal.Parse(currentProduct[1]);

                var product = new Product(productName, cost);
                this.products.Add(product);
            }
        }

        private void PrintOutput()
        {
            foreach (var person in this.persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
