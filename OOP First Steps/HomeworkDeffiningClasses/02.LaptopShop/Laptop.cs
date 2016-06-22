using System;

class Laptop
{
    private string model;
    private string manufacturer;
    private string procesor;
    private int ram;
    private string graphics;
    private string hdd;
    private string screen;
    private Battery batt;
    private double price;

    public Laptop(string model, double price)
    {
        this.Model = model;
        this.Price = price;
    }

    public Laptop(string model, double price, Battery battery, string manufacturer) 
        : this (model, price)
    {
        this.Manufacturer = manufacturer;
        this.batt = battery;
    }

    public Laptop(string model, double price, Battery battery, string manufacturer = null, 
        string procesor = null, int ram = 0, string graphics = null, string hdd = null, 
        string screen = null) : this (model, price, battery, manufacturer)
    {
        this.Procesor = procesor;
        this.Ram = ram;
        this.Graphics = graphics;
        this.Hdd = hdd;
        this.Screen = screen;
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new Exception("Model field can NOT be empty!");
            this.model = value;
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set { this.model = value; }
    }

    public string Procesor
    {
        get { return this.procesor; }
        set { this.procesor = value; }
    }

    public int Ram
    {
        get { return this.ram; }
        set
        {
            if (value < 0)
                throw new Exception("RAM can contain only positive numbers!");
            this.ram = value;
        }
    }

    public string Graphics
    {
        get { return this.graphics; }
        set { this.graphics = value; }
    }

    public string Hdd
    {
        get { return this.hdd; }
        set { this.hdd = value; }
    }

    public string Screen
    {
        get { return this.screen; }
        set { this.screen = value; }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
                throw new Exception("Price field is mandatory");
            this.price = value;
        }
    }

    public override string ToString()
    {
        string output = "Model: " + this.model + "\n";
        if (!string.IsNullOrWhiteSpace(this.manufacturer))
            output += "Manufacturer: " + this.manufacturer + "\n";
        if (!string.IsNullOrWhiteSpace(this.procesor))
            output += "Procesor: " + this.procesor + "\n";
        if (this.ram != 0)
            output += "RAM: " + this.ram + " GB\n";
            if (!string.IsNullOrWhiteSpace(this.graphics))
            output += "Graphic card: " + this.graphics + "\n";
        if (!string.IsNullOrWhiteSpace(this.hdd))
            output += "HDD: " + this.hdd + "\n";
        if (!string.IsNullOrWhiteSpace(this.screen))
            output += "Screen: " + this.screen + "\n";
        output += batt + "\n";

        output += "Price: " + this.price + " lv.\n";

        return output;
    }
}

