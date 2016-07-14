namespace KremenCity.Models
{
    public class SingleOld : SinglePerson
    {
        private const int RoomsCount = 1;
        private const decimal SingleRoomCost = 15;

        public SingleOld(decimal earning)
            : base(earning)
        {
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + (RoomsCount * SingleRoomCost);
            }
        }
    }
}
