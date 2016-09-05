using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Cores
{
    public class SystemCore : BaseCore
    {
        private const CoreType Type = CoreType.SystemCore;

        public SystemCore(int durability)
            : base(durability, Type)
        {
        }
    }
}
