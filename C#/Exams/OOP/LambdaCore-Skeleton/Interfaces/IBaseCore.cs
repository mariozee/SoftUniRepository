using LambdaCore_Skeleton.Collection;

namespace LambdaCore_Skeleton.Interfaces
{
    public interface IBaseCore
    {
        LStack<IBaseFragment> Fragments { get; }

        string Name { get; }

        int Durability { get; }

        int InitialDurability { get; }

        void AttachFragment(IBaseFragment fragment);

        IBaseFragment DetachFragmnet();
    }
}
