namespace _04.ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products { get; private set; }

        public string BuyProduct(Product product)
        {
            string message = string.Empty;
            if (this.Money >= product.Cost)
            {
                message = $"{this.Name} bought {product.Name}";
                this.Money -= product.Cost;
                this.Products.Add(product);
            }
            else
            {
                message = $"{this.Name} can't afford {product.Name}";
            }

            return message;
        }


    }
}
