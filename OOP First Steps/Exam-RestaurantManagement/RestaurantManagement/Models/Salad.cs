namespace RestaurantManagement.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Salad : AbstractRecipe, ISalad
    {
        private const bool DefaultSaladVeganStance = true;

        public Salad(
            string name, 
            decimal price, 
            int calories, 
            int quantity, 
            int timeToPrepare,
            bool containPasta)
            : base(name, price, calories, quantity, timeToPrepare)
        {
            this.ContainPasta = containPasta;
            this.IsVegan = DefaultSaladVeganStance;
        }

        public bool ContainPasta { get; }

        public bool IsVegan { get; }

        public void ToggleVegan()
        {
            throw new InvalidOperationException("salad those not support that option");
        }
    }
}
