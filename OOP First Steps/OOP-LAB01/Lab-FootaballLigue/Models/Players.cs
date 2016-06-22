using System;

public class Players
{
    private const int minimumAllowedYear = 1980;

    private string firstName;
    private string lastName;
    private decimal salary;
    private DateTime dateOfBirth;

    public Players(string firstName, string lastName, decimal salary, DateTime dateOfBirth)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Salary = salary;
        this.DateIfBirth = dateOfBirth;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("First name should be at least 3 symbols!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("Last name should be at least 3 symbols!");
            }
            this.lastName = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Salary cant be negative nubmber!");
            }
            this.salary = value;
        }
    }

    public DateTime DateIfBirth
    {
        get { return this.dateOfBirth; }
        set
        {
            if (value.Year < minimumAllowedYear)
            {
                throw new ArgumentOutOfRangeException("Date of birth must be after 1980!");
            }
            this.dateOfBirth = value;
        }
    }


}

