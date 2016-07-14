namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.1m;
        private decimal notConvertedHeight;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.notConvertedHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                base.Height = ConvertedHeight;
                this.IsConverted = true;
            }
            else
            {
                base.Height = notConvertedHeight;
                this.IsConverted = false;
            }
        }

        public override string ToString()
        {
            string output = string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");

            return output;
        }
    }
}
