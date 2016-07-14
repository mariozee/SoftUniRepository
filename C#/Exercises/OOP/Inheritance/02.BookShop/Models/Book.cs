namespace _02.BookShop.Models
{
    using System;

    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get { return this.author; }
            protected set
            {
                string[] authorNames = value.Split();
                if (authorNames.Length > 1)
                {
                    if (char.IsDigit(authorNames[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }
        
        public virtual double Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format("Type: {0}{4}Title: {1}{4}Author: {2}{4}Price: {3:F1}{4}"
                , this.GetType().Name, this.Title, this.Author, this.Price, Environment.NewLine);

            return output;
        }
    }
}
