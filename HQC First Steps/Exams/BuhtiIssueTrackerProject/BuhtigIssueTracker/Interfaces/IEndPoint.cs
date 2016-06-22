namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string actionName { get; }

        IDictionary<string, string> parameter { get; }
    }
}
