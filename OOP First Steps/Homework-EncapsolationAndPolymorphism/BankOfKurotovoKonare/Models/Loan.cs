using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfKurotovoKonare.Enum;
namespace BankOfKurotovoKonare
{
    using Interfaces;

    class Loan : Account, IDepositable
    {
        public Loan(string customerName, double balance, double interestRate, CustomerTape customerTape)
            : base(customerName, balance, interestRate, customerTape)
        {
        }

        public override double InterestCalculator(int month)
        {
            if (this.CustomerTape == CustomerTape.Company)
                month -= 2;
            else
                month -= 3;

            return base.InterestCalculator(month);
        }

        public void DepositMoney(double moneyToDeposit)
        {
            this.Balance += moneyToDeposit;
        }

        public override string ToString()
        {
            return string.Format("{0}Account Type:  {1}", base.ToString(), this.GetType().Name);
        }
    }
}
