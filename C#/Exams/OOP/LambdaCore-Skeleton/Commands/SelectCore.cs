using LambdaCore_Skeleton.Engine;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Commands
{
    public class SelectCore : Command
    {
        public SelectCore(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            string coreName = this.Params[0];
            this.CoreData.SetCore(coreName);

            string message = string.Format(GlobalMessages.SuccessSelectedCore, coreName);
            return message;
        }
    }
}
