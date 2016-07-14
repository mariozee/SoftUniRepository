namespace KremenCity.Models
{
    public class OldCouple : Couple
    {
        private const int RoomsCount = 3;
        private const decimal SingleRoomCost = 15;

        private decimal stoveCost;

        public OldCouple(decimal earning1, decimal earning2, decimal tvCost, decimal fridgeCost, decimal stoveCost)
            : base(earning1, earning2, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.stoveCost + (RoomsCount * SingleRoomCost);
            }
        }
    }
}
