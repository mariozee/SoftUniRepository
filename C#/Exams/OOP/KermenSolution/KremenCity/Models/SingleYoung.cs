namespace KremenCity.Models
{
    public class SingleYoung : SinglePerson
    {
        private const int RoomsCount = 1;
        private const decimal SingleRoomCost = 10;

        private decimal laptopCost;

        public SingleYoung(decimal earning, decimal laptopCost)
            : base(earning)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.laptopCost + (RoomsCount * SingleRoomCost);
            }
        }
    }
}
