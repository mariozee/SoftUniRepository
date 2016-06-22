using System;
using System.Collections.Generic;

class Computer
{
    private string name;
    private double price;
    private List<Component> components = new List<Component>();

    public Computer(string name, params Component[] components)
    {
        this.name = name;
        foreach (var com in components)
        {
            this.components.Add(com);
            this.price += com.CompPrice;
        }
    }

    public string Name  
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Component name can't be empty");
            this.name = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Computer Price can't be negative number");
            this.price = value;
        }
    }

    public override string ToString()
    {
        string output = "Computer Name: " + this.name + "\n\n";
        foreach (var com in this.components)
        {
            output += com.ToString();
        }
        output += "Total: " + this.price.ToString() + " BGN\n";
        output += "--------------------------\n";

        return output;
    }
}

