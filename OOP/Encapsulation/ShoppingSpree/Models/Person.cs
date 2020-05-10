using System;
using System.Collections.Generic;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstant.InvalidNameException);
                }
                this.name = value;
            }
        }


        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstant.InvalidMoneyException);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(String.Format(GlobalConstant.InssuficientMoneyException, this.Name, product.Name));
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {

            var productsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
