namespace BuhtigIssueTracker.Interfaces
{
    public interface IUser
    {
        string UserName { get; }

        string PasswordHash { get; }
    }
}
