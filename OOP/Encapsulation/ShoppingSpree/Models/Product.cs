using System;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
	
   public class Product
    {
		private string name;
		private decimal cost;

		public Product(string name, decimal cost)
		{
			this.Name = name;
			this.Cost = cost;
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

		

		public decimal Cost
		{
			get { return this.cost; }
			private set 
			{
				if (value < 0)
				{
					throw new InvalidOperationException(GlobalConstant.InvalidMoneyException);
				}
				this.cost = value;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
