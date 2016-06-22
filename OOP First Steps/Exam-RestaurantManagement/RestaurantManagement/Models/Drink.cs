namespace RestaurantManagement.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Drink : AbstractRecipe, IDrink
    {
        public Drink(
            string name, 
            decimal price, 
            int calories, 
            int quantity, 
            int timeToPrepare, 
            bool isCabonaed)
            : base(name, price, calories, quantity, timeToPrepare)
        {
            this.IsCarbonated = IsCarbonated;
        }

        public bool IsCarbonated { get; }
    }
}
