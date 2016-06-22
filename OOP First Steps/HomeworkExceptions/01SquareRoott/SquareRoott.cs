using System;

class SquareRoott
{
    static void Main()
    {
        try
        {
            Console.Write("Enter integer number: ");
            int n = int.Parse(Console.ReadLine());
            
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("Input cant be negative");
            }

            Console.WriteLine("Square root of {0} is {1}", n, Math.Sqrt(n)); 

        }
        catch (FormatException x)
        {
            Console.WriteLine(x.Message);
        }
        catch (ArgumentOutOfRangeException x)
        {
            Console.WriteLine(x.Message);
        }
        catch (OverflowException x)
        {
            Console.WriteLine(x.Message);
        }
        finally
        {
            Console.WriteLine("Good Buy.");
            Console.WriteLine();
        }
    }
}

