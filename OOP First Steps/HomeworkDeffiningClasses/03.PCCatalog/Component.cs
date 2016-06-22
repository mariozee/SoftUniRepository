using System;

class Component
{
    private string compName;
    private double compPrice;

    public Component(string compName, double compPrice, string compDetail = null)
    {
        this.CompName = compName;
        this.CompDetail = compDetail;
        this.CompPrice = compPrice;
    }


    public string CompName
    {
        get { return this.compName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Component name can't be empty");
            this.compName = value;
        }
    }

    public string CompDetail { get; set; }

    public double CompPrice
    {
        get { return this.compPrice; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Price can't be negative number!");
            this.compPrice = value;
        }
    }

    public override string ToString()
    {
        string output = "Component: " + this.CompName + "\n";

        if (string.IsNullOrWhiteSpace(this.CompDetail))
            output += "Details: (not specified)\n";
        else
            output += "Detail: " + this.CompDetail + "\n";
        output += "Price :" + this.CompPrice + " BGN\n\n";

        return output;
    }
}

