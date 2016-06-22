namespace BuhtigIssueTracker.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        IUser CurrentlyLoggedUser { get; set; }

        IDictionary<string, IUser> UsersData { get; }

        OrderedDictionary<int, IIssue> IdIssueData { get; }

        MultiDictionary<string, IIssue> UsernameIssueData { get; }

        MultiDictionary<string, IIssue> TagIssueData { get; }

        MultiDictionary<IUser, IComment> UserCommentData { get; }

        int AddIssue(IIssue p);

        void RemoveIssue(IIssue p);
    }
}
