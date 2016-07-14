namespace KremenCity.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class YoungCoupleWithChildren : Couple
    {
        private const int RoomsCount = 2;
        private const decimal SingleRoomCost = 30;

        private decimal laptopCost;
        private List<Child> childs;

        public YoungCoupleWithChildren(decimal earning1, decimal earning2, decimal tvCost, decimal fridgeCost, decimal laptopCost, List<Child> childs)
            : base(earning1, earning2, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
            this.childs = childs;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + (RoomsCount * SingleRoomCost) + (2 * this.laptopCost) + (this.childs.Sum(c => c.ChildConsuption));
            }
        }

        public override int PeopleCount
        {
            get
            {
                return base.PeopleCount + this.childs.Count();
            }
        }
    }
}
