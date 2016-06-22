namespace BankOfKurotovoKonare.Models
{
    using Enum;
    using Interfaces;

    class Mortage : Account, IDepositable
    {
        public Mortage(string customerName, double balance, double interestRate, CustomerTape customerTape)
            : base(customerName, balance, interestRate, customerTape)
        {
        }

        public override double InterestCalculator(int month)
        {
            month -= 6;
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
