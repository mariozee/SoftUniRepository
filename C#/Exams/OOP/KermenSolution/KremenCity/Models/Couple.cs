namespace KremenCity.Models
{
    public abstract class Couple : Household
    {
        private decimal earning1;
        private decimal earning2;
        private decimal tvCost;
        private decimal fridgeCost;

        public Couple(decimal earning1, decimal earning2, decimal tvCost, decimal fridgeCost)
        {
            this.earning1 = earning1;
            this.earning2 = earning2;
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override decimal Income
        {
            get
            {
                return base.Income + earning1 + earning2;
            }
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.tvCost + this.fridgeCost;
            }
        }

        public override int PeopleCount
        {
            get
            {
                return base.PeopleCount + 2;
            }
        }
    }
}