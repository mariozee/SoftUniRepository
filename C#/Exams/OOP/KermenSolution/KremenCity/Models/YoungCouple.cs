namespace KremenCity.Models
{
    public class YoungCouple : Couple
    {
        private const int RoomsCount = 2;
        private const decimal SingleRoomCost = 20;

        private decimal laptopCost;

        public YoungCouple(decimal earning1, decimal earning2, decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(earning1, earning2, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }
        
        public override decimal Consumption
        {
            get
            {
                return base.Consumption + (RoomsCount * SingleRoomCost) + (this.laptopCost * base.PeopleCount);
            }
        }
    }
}
