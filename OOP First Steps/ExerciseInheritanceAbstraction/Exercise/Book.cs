using System;
using System.Text;

class Book
{
    private string title;
    private string aouthor;
    private decimal price;

    public Book(string title, string aouthor, decimal price)
    {
        this.Title = title;
        this.Aouthor = aouthor;
        this.Price = price;
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("There is no book withouth Title");
            }
            this.title = value;
        }
    }

    public string Aouthor
    {
        get { return this.aouthor; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("There is no book withouth Aouthor");
            }
            this.aouthor = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be positive number");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        output.AppendFormat("-Type: {0}{1}", this.GetType().Name, Environment.NewLine);
        output.AppendFormat("-Title: {0}{1}", this.Title, Environment.NewLine);
        output.AppendFormat("-Author: {0}{1}", this.Aouthor, Environment.NewLine);
        output.AppendFormat("-Price: {0:F2}{1}", this.Price, Environment.NewLine);

        return output.ToString();
    }
}

