using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories.Models
{
    public class Topping
    {
        private const double MinToppingWeight = 1;
        private const double MaxToppingWeight = 50;

        private string toppingType;
        private double weight;

        private Dictionary<string, double> toppingTypes = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
            this.Calories = CalculateCalories();
        }

        public double Calories { get; private set; }

        public string ToppingType
        {
            get { return this.toppingType; }
            private set
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (MinToppingWeight > value || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double totalCalories = this.Weight * 2 * toppingTypes[this.ToppingType.ToLower()];

            return totalCalories;
        }
    }
}