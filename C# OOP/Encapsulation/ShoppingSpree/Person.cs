using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstant.InvalidNameException);
                }
                this.name = value;
            }
        }


        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstant.InvalidMoneyException);
                }
                this.money = value;
            }
        }

        public string Buy(Product product)
        {
            var stringToReturn = string.Empty;

            if (product != null)
            {
                if (this.Money >= product.Cost)
                {
                    this.Money -= product.Cost;
                    stringToReturn = string.Format("{0} bought {1}", this.Name, product.Name);
                    this.bag.Add(product);
                }
                else
                {
                    stringToReturn = string.Format("{0} can't afford {1}", this.Name, product.Name);
                }
            }

            return stringToReturn;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.bag.Any())
            {
                sb.AppendLine(string.Format("{0} - {1}", this.Name, string.Join(", ", this.bag.Select(x => x.Name))));
            }
            else
            {
                sb.AppendLine(string.Format("{0} - Nothing bought", this.Name));
            }



            return sb.ToString().TrimEnd();
        }
    }
}
