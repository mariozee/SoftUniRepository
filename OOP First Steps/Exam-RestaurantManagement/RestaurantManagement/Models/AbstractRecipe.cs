namespace RestaurantManagement.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class AbstractRecipe : IRecipe
    {
        public AbstractRecipe(
            string name,
            decimal price,
            int calories,
            int quantity,
            int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.Quantity = quantity;
            this.TimeToPrepare = timeToPrepare;
        }

        public int Calories { get; }

        public string Name { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        public int TimeToPrepare { get; }
    }
}
