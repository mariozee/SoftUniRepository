using System;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main()
        {
            string[] array = Console.ReadLine().Split(' ');
            Action<string> print = s => Console.WriteLine(s);
            foreach (var element in array)
            {
                print(element);
            }
        }
    }
}
