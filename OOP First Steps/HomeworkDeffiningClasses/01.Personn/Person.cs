using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    public Person(string name, int age) : this(name, null, age)
    {
    }

    public Person(string name, string email, int age)
    {
        this.Name = name;
        this.Email = email;
        this.Age = age;
    }

    private string name;
    private int age;
    private string email;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!value.All(Char.IsLetter) || (value == null))
            {
                throw new Exception("The name shoud contain olny letters.");
            }
            this.name = value;
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if (value != null && !value.Contains("@"))
            {
                this.email = null;
            }
            else
            {
                this.email = value;
            }
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new Exception("The age must between 1 and 100");
            }
            this.age = value;
        }
    }

    public override string ToString()
    {
        if (email != null)
        {
            return String.Format("Name: {0}{3}Age: {1}{3}Email: {2}", this.Name,
                this.Age, this.Email, Environment.NewLine);
        }
        else
        {
            return String.Format("Name: {0}{2}Age: {1}", this.Name,
                this.Age, Environment.NewLine);
        }
    }
}

