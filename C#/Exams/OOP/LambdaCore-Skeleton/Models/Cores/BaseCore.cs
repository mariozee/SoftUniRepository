namespace LambdaCore_Skeleton.Models.Cores
{
    using System;
    using Interfaces;
    using Collection;
    using Enums;
    using Fragments;

    public abstract class BaseCore : IBaseCore
    {
        private static char name = (char)65;

        private int durability;

        protected BaseCore(int durability, CoreType type)
        {
            this.durability = durability;
            this.Fragments = new LStack<IBaseFragment>();
            this.Name = name.ToString();
            this.Type = type;
            this.InitialDurability = durability;

            name++;
        }

        public LStack<IBaseFragment> Fragments { get; private set; }

        public string Name { get; protected set; }

        public CoreType Type { get; protected set; }

        public int InitialDurability { get; private set; }

        public virtual int Durability
        {
            get { return this.durability; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(GlobalMessages.FailedCreatedCore);
                }

                this.durability = value;
            }
        }

        public void AttachFragment(IBaseFragment fragment)
        {
            this.Fragments.Push(fragment);

            if (fragment.GetType() == typeof(CoolingFragment))
            {
                this.Durability += fragment.PressureAffection;
            }
            else
            {
                if (this.Durability - fragment.PressureAffection < 0)
                {
                    this.Durability = 0;
                }

                this.Durability -= fragment.PressureAffection;
            }
            
        }

        public IBaseFragment DetachFragmnet()
        {
            var fragment = this.Fragments.Pop();

            if (fragment.GetType() == typeof(CoolingFragment))
            {
                if (this.Durability - fragment.PressureAffection < 0)
                {
                    this.Durability = 0;
                }

                this.Durability -= fragment.PressureAffection;
            }
            else
            {
                this.Durability += fragment.PressureAffection;
            }            

            return fragment;
        }
    }
}
