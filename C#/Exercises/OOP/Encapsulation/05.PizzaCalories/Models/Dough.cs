using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories.Models
{
    public class Dough
    {
        private const double MinDoughWeight = 1;
        private const double MaxDoughWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1 }
        };

        private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.Calories = CalculateCalories();
        }

        public double Calories { get; private set; }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (MinDoughWeight > value || value > MaxDoughWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double CalculateCalories()
        {
            double totalCal = this.Weight * 2 * flourTypes[this.FlourType.ToLower()] * bakingTechniques[this.BakingTechnique.ToLower()];

            return totalCal;
        }
    }
}