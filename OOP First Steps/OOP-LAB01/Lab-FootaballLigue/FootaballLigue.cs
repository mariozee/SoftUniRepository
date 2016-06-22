using System;

class FootabllLegue
{
    public static void Main()
    {
        Console.WriteLine("Options:");
        Console.WriteLine("AddTeam [team name] [team nickname] [date founded]");
        Console.WriteLine("AddMatch [team name] [team nickname] [date founded] [team name] [team nickname] [date found] [team 1 score] [team 2 score] [match id]");
        Console.WriteLine("AddPlayerToTeam [first name] [last name] [salary] [date of birth] [team name]");
        Console.WriteLine("ListMatches - Prints all matches");
        Console.WriteLine("ListTeams - Prints all teams");
        string input = Console.ReadLine();
        while (input != "End")
        {
            try
            {
               League.HandleInput(input);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            input = Console.ReadLine();
        }
    }
}







