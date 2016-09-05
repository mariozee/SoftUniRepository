using LambdaCore_Skeleton.Commands;
using LambdaCore_Skeleton.Engine;
using LambdaCore_Skeleton.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreData = new CoreData();
            var engine = new PowerPlantEngine(coreData);
            engine.Start();
        }
    }
}
