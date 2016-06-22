using System;

class EnterNumbers
{
    static void Main()
    {
        int counter = 0;
        int start = 1;

        while (counter < 10)
        {
            try
            {
                int currentNum = ReadNumber(start, 100);

                if (currentNum > start)
                {
                    start = currentNum;
                }

                counter++;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
                Console.WriteLine("Enter onather number.");
            }
            catch (FormatException fx)
            {
                Console.WriteLine(fx.Message);
                Console.WriteLine("Enter onather number.");
            }
        }
    }

    static int ReadNumber(int start, int end)
    {
        int n = int.Parse(Console.ReadLine());

        if (n <= start || end < n)
        {
            throw new ArgumentOutOfRangeException("Number should be bigger than previous number and smaller than 100");
        }

        return n;
    }
}

