namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;
    using Interfaces;
    using System;

    public abstract class BaseFragment : IBaseFragment
    {
        private string name;
        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection, FragmentType type)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.Type = type;
        }

        public string Name { get; protected set; }

        public FragmentType Type { get; protected set; }

        public virtual int PressureAffection
        {
            get { return this.pressureAffection; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(GlobalMessages.FailedAttachFragment, this.Name));
                }

                this.pressureAffection = value;
            }
        }
    }
}
