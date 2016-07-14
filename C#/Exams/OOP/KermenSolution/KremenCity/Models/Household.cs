namespace KremenCity.Models
{
    public abstract class Household
    {
        private decimal income;
        private decimal balance;
        private decimal consuption;
        private int peopleCount;

        public virtual decimal Income
        {
            get { return this.income; }
            private set { this.income = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            private set { this.balance = value; }
        }

        public virtual decimal Consumption
        {
            get { return this.consuption; }
            private set { this.consuption = value; }
        }

        public virtual int PeopleCount
        {
            get { return this.peopleCount; }
            private set { this.peopleCount = value; }
        }

        public bool CanPayBill()
        {
            bool canPay = this.Balance - this.Consumption >= 0;

            return canPay;
        }

        public void PayBill()
        {
            this.Balance -= this.Consumption;
        }

        public void CollectIncome()
        {
            this.Balance += this.Income;
        }
    }
}
