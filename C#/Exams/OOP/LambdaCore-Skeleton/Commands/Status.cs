using LambdaCore_Skeleton.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaCore_Skeleton.Commands
{
    public class Status : Command
    {
        public Status(CoreData coreData, string[] parametars)
            : base(coreData, parametars)
        {
        }

        public override string Execute()
        {
            StringBuilder sb = new StringBuilder();
            int totalDurability = this.CoreData.Data.Select(p => p.Value.Durability).Sum();
            int totalCores = this.CoreData.Data.Count;
            int totalFragment = this.CoreData.Data.Select(p => p.Value.Fragments.Count()).Sum();

            sb.AppendLine("Lambda Core Power Plant Status:")
                .AppendLine($"Total Durability: {totalDurability}")
                .AppendLine($"Total Cores: {totalCores}")
                .AppendLine($"Total Fragments: {totalFragment}");

            foreach (var core in this.CoreData.Data.Values)
            {
                sb.AppendLine($"Core {core.Name}")
                    .AppendLine($"####Durability: {core.Durability}")
                    .AppendFormat("####Status: {0}", core.Durability >= core.InitialDurability ? "NORMAL" : "CRITICAL")
                    .AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
