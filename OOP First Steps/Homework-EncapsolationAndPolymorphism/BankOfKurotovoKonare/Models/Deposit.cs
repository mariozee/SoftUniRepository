namespace BankOfKurotovoKonare
{
    using Enum;
    using Interfaces;

    public class Deposit : Account, IWithdrawable, IDepositable
    {
        public Deposit(string customerName, double balance, double interestRate, CustomerTape customerTape)
            : base(customerName, balance, interestRate, customerTape)
        {
        }

        public override double InterestCalculator(int month)
        {
            if (this.Balance > 0 && this.Balance < 1000)
                this.InterestRate = 0;

            return base.InterestCalculator(month);
        }

        public void WithdrawMoney(double moneyToWithdraw)
        {
            this.Balance -= moneyToWithdraw;
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
