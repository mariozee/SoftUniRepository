namespace BuhtigIssueTracker.Core
{
    using Interfaces;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using Models;

    public class Data : IBuhtigIssueTrackerData
    {
        private int nextIssueId;

        public Data()
        {
            nextIssueId = 1;
            this.UsersData = new Dictionary<string, IUser>(); 
            this.IdIssueData = new OrderedDictionary<int, IIssue>();
            this.UsernameIssueData = new MultiDictionary<string, IIssue>(true);
            this.TagIssueData = new MultiDictionary<string, IIssue>(true);
            this.UserCommentData = new MultiDictionary<IUser, IComment>(true);
            this.CommentUserData = new Dictionary<IComment, IUser>();
        }
        
        public IUser CurrentlyLoggedUser { get; set; }

        public IDictionary<string, IUser> UsersData { get; set; }

        public OrderedDictionary<int, IIssue> IdIssueData { get; set; }

        public MultiDictionary<string, IIssue> UsernameIssueData { get; set; }

        public MultiDictionary<string, IIssue> TagIssueData { get; set; }

        public MultiDictionary<IUser, IComment> UserCommentData { get; set; }

        public Dictionary<IComment, IUser> CommentUserData { get; set; }

        public int AddIssue(IIssue issue)
        {
            issue.Id = this.nextIssueId;
            this.IdIssueData.Add(issue.Id, issue);
            this.nextIssueId++;
            this.UsernameIssueData[this.CurrentlyLoggedUser.UserName].Add(issue);

            foreach (var tag in issue.Tags)
            {
                this.TagIssueData[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(IIssue issue)
        {
            this.UsernameIssueData[this.CurrentlyLoggedUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagIssueData[tag].Remove(issue);
            }

            this.IdIssueData.Remove(issue.Id);
        }
    }
}