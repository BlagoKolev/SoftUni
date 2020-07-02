using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                var command = Console.ReadLine().Split();
                if (command[0] == "END")
                {
                    break;
                }

                var personName = command[0];
                var productName = command[1];
                try
                {
                    var currentPerson = persons.Where(x => x.Name == personName).FirstOrDefault();
                    var currentProduct = products.Where(x => x.Name == productName).FirstOrDefault();
                    Console.WriteLine(currentPerson.Buy(currentProduct));
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

