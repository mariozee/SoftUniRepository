using LambdaCore_Skeleton.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Commands
{
    public class RemoveCore : Command
    {
        public RemoveCore(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            string coreName = this.Params[0];
            this.CoreData.Remove(coreName);

            string message = string.Format(GlobalMessages.SuccessfullyRemovedCore, coreName);
            return message;
        }
    }
}
