using LambdaCore_Skeleton.Engine;
using LambdaCore_Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Commands
{
    public abstract class Command
    {
        protected Command(CoreData coreData, string[] parametars)
        {
            this.CoreData = coreData;
            this.Params = parametars;
        }

        public CoreData CoreData { get; protected set; }

        public string[] Params { get; protected set; }

        public abstract string Execute();
    }
}
