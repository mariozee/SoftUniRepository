using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories.Models
{
    public class Pizza
    {
        private const int MinNameLenght = 1;
        private const int MaxNameLenght = 15;
        private const int MinToppingNumber = 0;
        private const int MaxToppingNumber = 10;

        private string name;
        private int toppigCount;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, int toppingCount)
        {
            this.Name = name;
            this.ToppingCount = toppingCount;
            toppings = new List<Topping>();
        }

        public double Calories { get; private set; }

        public Dough Dough
        {
            get { return this.dough; }
            set
            {
                this.Calories = value.Calories;
                this.dough = value;
            }
        }

        public int ToppingCount
        {
            get { return this.toppigCount; }
            private set
            {
                if (MinToppingNumber > value || value > MaxToppingNumber)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.toppigCount = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || MinNameLenght > value.Length || value.Length > MaxNameLenght)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void AddToppin(Topping topping)
        {
            this.toppings.Add(topping);
            this.Calories += topping.Calories;
        }
    }
}