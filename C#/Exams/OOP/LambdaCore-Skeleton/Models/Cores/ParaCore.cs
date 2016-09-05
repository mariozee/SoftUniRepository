namespace LambdaCore_Skeleton.Models.Cores
{
    using Enums;
    using System;

    public class ParaCore : BaseCore
    {
        private const CoreType Type = CoreType.ParaCore;

        public ParaCore(int durability)
            : base(durability, Type)
        {
        }

        public override int Durability
        {
            get
            {
                return base.Durability / 3;
            }
        }
    }
}
