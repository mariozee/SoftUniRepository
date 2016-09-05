using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LambdaCore_Skeleton.Engine;
using System.Reflection;
using LambdaCore_Skeleton.Interfaces;
using LambdaCore_Skeleton.Models.Cores;

namespace LambdaCore_Skeleton.Commands
{
    public class CreateCore : Command
    {
        public CreateCore(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            string coreName = this.Params[0];
            int durability = int.Parse(this.Params[1]);
            var coreType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == (coreName + "Core"));
            if (coreType == null)
            {
                throw new ArgumentNullException(GlobalMessages.FailedCreatedCore);
            }

            var core = Activator.CreateInstance(coreType, durability) as BaseCore;
            this.CoreData.Add(core.Name, core);

            string message = string.Format(GlobalMessages.SuccessfullyCreatedCore, core.Name);
            return message;
        }
    }
}
