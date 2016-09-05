namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;

    class CoolingFragment : BaseFragment
    {
        private const FragmentType Type = FragmentType.Cooling;

        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection, Type)
        {
        }

        public override int PressureAffection
        {
            get
            {
                return base.PressureAffection * 3;
            }
        }
    }
}
