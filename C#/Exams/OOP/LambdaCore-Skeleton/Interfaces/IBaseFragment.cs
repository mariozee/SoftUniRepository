namespace LambdaCore_Skeleton.Interfaces
{
    using Enums;

    public interface IBaseFragment
    {
        string Name { get; }

        FragmentType Type { get; }

        int PressureAffection { get; }
    }
}
