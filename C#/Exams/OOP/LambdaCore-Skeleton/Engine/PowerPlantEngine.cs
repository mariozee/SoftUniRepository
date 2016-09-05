using LambdaCore_Skeleton.Commands;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Engine
{
    public class PowerPlantEngine
    {
        private CoreData coreData;

        public PowerPlantEngine(CoreData coreData)
        {
            this.coreData = coreData;
        }

        public void Start()
        {
            string line = Console.ReadLine();

            while (line != "System Shutdown!")
            {
                try
                {
                    var parser = new InputParser(line);
                    var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == parser.CommandName);
                    if (commandType == null)
                    {
                        continue;
                    }

                    var command = Activator.CreateInstance(commandType, this.coreData, parser.Parameters) as Command;
                    string message = command.Execute();

                    Console.WriteLine(message);                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.ParamName);
                }

                line = Console.ReadLine();

            }
        }
    }
}
