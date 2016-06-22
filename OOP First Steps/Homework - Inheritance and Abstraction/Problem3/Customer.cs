namespace Problem3
{
    using System;
    using Interfaces;

    class Customer : Person, ICustomer
    {
        public Customer(string firstName, string lastName, string id, decimal netPurchased)
            : base(firstName, lastName, id)
        {
            this.NetPurchased = netPurchased;
        }

        public decimal NetPurchased { get; set; }

        public override string ToString()
        {
            return string.Format("Customer name: {0}. Net Purchaesd - {1}", 
                this.FirstName, this.NetPurchased);
        }
    }
}
