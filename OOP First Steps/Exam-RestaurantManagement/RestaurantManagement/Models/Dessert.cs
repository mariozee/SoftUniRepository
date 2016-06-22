namespace RestaurantManagement.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dessert : AbstractRecipe, IDessert
    {
        public Dessert(
            string name, 
            decimal price, 
            int calories, 
            int quantity, 
            int timeToPrepare,
            bool isVegan)
            : base(name, price, calories, quantity, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; private set; }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}
