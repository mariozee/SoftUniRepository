using System;
namespace Problem3.Interfaces
{
    class Sale : ISale
    {
        private string name;

        private decimal price;

        public Sale(string name, DateTime date, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Date = date;
        }

        public DateTime Date { get; set; }

        public string Name
        {
            get
            { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Product Name", "Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product price", "Price cannot be negative number");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{2}Product name: {0}{2}Price: {1}{2}",
                this.Name, this.Price, Environment.NewLine);
        }
    }
}
