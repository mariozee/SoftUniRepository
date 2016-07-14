namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;
    using System.Text;

    public class Company : IComapny
    {
        private const int MinNameLenght = 5;
        private const int RegisrationLenght = 10;

        //private ICollection<IFurniture> furnitures;
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < MinNameLenght || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                if (value.Length != RegisrationLenght || !IsDigitsOnly(value))
                {
                    throw new ArgumentException();
                }

                this.registrationNumber = value;
            }
        }
                
        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - {1} - {2} {3}{4}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture",
                Environment.NewLine);

            var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
            foreach (var furniture in sortedFurnitures)
            {
                sb.AppendLine(furniture.ToString());
            }

            return sb.ToString();
        }

        public IFurniture Find(string model)
        {
            var furniture = this.Furnitures.Where(f => f.Model == model).FirstOrDefault();

            return furniture;
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        private bool IsDigitsOnly(string regNumber)
        {
            foreach (var ch in regNumber)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
