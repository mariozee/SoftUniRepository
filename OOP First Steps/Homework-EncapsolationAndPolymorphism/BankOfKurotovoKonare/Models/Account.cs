namespace BankOfKurotovoKonare
{
    using System;
    using Interfaces;
    using Enum;

    public abstract class Account : IAccount
    {
        public Account(string customerName, double balance, double interestRate, CustomerTape customerTape)
        {
            this.CustomerName = customerName;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.CustomerTape = customerTape;
        }

        public double Balance { get; protected set; }
 
        public string CustomerName { get; protected set; }

        public double InterestRate { get; protected set; }

        public CustomerTape CustomerTape { get; protected set; }

        public virtual double InterestCalculator(int month)
        {
            if (month < 0)
                month = 0;

            double output = this.Balance * (1 + InterestRate * month);

            return output;
        }

        public override string ToString()
        {
            return string.Format("Customer:      {0}{4}Balance:       {1}{4}"
                + "Interest Rate: {2}{4}Customer Type: {3}{4}",
                 this.CustomerName, this.Balance, this.InterestRate, this.CustomerTape, Environment.NewLine);
        }
    }
}
