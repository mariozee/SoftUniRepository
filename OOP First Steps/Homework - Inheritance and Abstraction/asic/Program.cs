using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asic
{
    class Program
    {
        static void Main(string[] args)
        {
            int firefighters = int.Parse(Console.ReadLine());
            int kidds = 0;
            int adults = 0;
            int seniors = 0;
            int fireFightersLeft = firefighters;

            while (true)
            {
                fireFightersLeft = firefighters;
                string command = Console.ReadLine();

                if (command == "rain")
                {
                    break;
                }

                for (int i = 0; i < command.Length; i++)
                {
                    if (fireFightersLeft == 0)
                        break;

                    if (command[i] == 'K')
                    {
                        kidds++;
                        fireFightersLeft--;
                    }                    
                }

                for (int i = 0; i < command.Length; i++)
                {
                    if (fireFightersLeft == 0)
                        break;

                    if (command[i] == 'A')
                    {
                        adults++;
                        fireFightersLeft--;
                    }
                }

                for (int i = 0; i < command.Length; i++)
                {
                    if (fireFightersLeft == 0)
                        break;

                    if (command[i] == 'S')
                    {
                        seniors++;
                        fireFightersLeft--;
                    }
                }
            }
            Console.WriteLine(kidds);
            Console.WriteLine(adults);
            Console.WriteLine(seniors);
        }
    }
}

