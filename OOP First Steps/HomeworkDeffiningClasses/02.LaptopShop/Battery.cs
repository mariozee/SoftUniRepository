using System;

class Battery
{
    private string batt;
    private double battLife;

    public Battery(string batt = null, double battLife = 0)
    {
        this.Batt = batt;
        this.BattLife = battLife;
    }

    public string Batt
    {
        get { return this.batt; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                this.batt = null;
            this.batt = value;
        }
    }   

    public double BattLife
    {
        get { return this.battLife; }
        set
        {
            if (value < 0)
                throw new Exception("Battery Life should be greather or equal to 0");
            this.battLife = value;
        }
    }

    public override string ToString()
    {
        return "Battery" + this.Batt + " Battery Life: " + this.BattLife;
    }
}
