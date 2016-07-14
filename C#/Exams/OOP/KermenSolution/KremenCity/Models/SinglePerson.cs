namespace KremenCity.Models
{
    public abstract class SinglePerson : Household
    {
        private decimal earning;

        public SinglePerson(decimal earning)
        {
            this.earning = earning;
        }

        public override decimal Income
        {
            get
            {
                return base.Income + earning;
            }
        }

        public override int PeopleCount
        {
            get
            {
                return base.PeopleCount + 1;
            }
        }
    }
}
