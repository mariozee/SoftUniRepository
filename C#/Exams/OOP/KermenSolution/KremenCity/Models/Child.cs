namespace KremenCity.Models
{
    public class Child
    {
        public Child(decimal childCinsuption)
        {
            this.ChildConsuption = childCinsuption;
        }

        public decimal ChildConsuption { get; private set; }
    }
}
