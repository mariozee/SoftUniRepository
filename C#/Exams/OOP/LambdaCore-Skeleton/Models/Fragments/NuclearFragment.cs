namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;

    public class NuclearFragment : BaseFragment
    {
        private const FragmentType Type = FragmentType.Nuclear;

        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection, Type)
        {
        }

        public override int PressureAffection
        {
            get
            {
                return base.PressureAffection * 2;
            }
        }
    }
}
