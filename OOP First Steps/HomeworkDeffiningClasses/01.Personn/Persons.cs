using System;
using System.Linq;


class Persons
{
    static void Main()
    {
        Console.Write("Add name: ");
        string personName = Console.ReadLine();

        Console.Write("Add age: ");
        int personAge = int.Parse(Console.ReadLine());

        Console.Write("Add email adress (optinal): ");
        string personEmail = Console.ReadLine();

        Console.WriteLine();

        Person newPerson = new Person(personName, personEmail, personAge);

        Console.WriteLine(newPerson);
    }
}

