using System;

class Exercise
{
    static void Main(string[] args)
    {
        Book b = new Book("OOP", "SoftUni", 22.50m);
        GoldenEditionBook c = new GoldenEditionBook("OOP", "SoftUni", 22.50m);

        Console.WriteLine(b);
        Console.WriteLine(c);
    }
}

