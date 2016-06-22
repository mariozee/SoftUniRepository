namespace BuhtigIssueTracker
{
    using Interfaces;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IssueTracker : IIssueTracker
    {
        IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public BuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (Data.CurrentlyLogedUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (Data.UserData.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            Data.UserData.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (Data.CurrentlyLogedUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (!Data.UserData.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = Data.UserData[username];
            if (user.PasswordHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            Data.CurrentlyLogedUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = Data.CurrentlyLogedUser.UserName;

            Data.CurrentlyLogedUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePrority priority, string[] tags)
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            issue.Id = Data.nextIssueId;
            Data.IdIssueDic.Add(issue.Id, issue);
            Data.nextIssueId++;
            Data.UserIssueDic[Data.CurrentlyLogedUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                Data.TagIssueDic[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!Data.IdIssueDic.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = Data.IdIssueDic[issueId];

            if (!Data.UserIssueDic[Data.CurrentlyLogedUser.UserName].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}",
                    issueId, 
                    this.Data.CurrentlyLogedUser.UserName);
            }

            Data.UserIssueDic[Data.CurrentlyLogedUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                Data.TagIssueDic[tag].Remove(issue);
            }

            Data.IdIssueDic.Remove(issue.Id);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueID, string message)
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!Data.IdIssueDic.ContainsKey(issueID))
            {
                return string.Format("There is no issue with ID {0}", issueID);
            }

            var issue = Data.IdIssueDic[issueID];
            var comment = new Comment(Data.CurrentlyLogedUser, message);
            issue.AddComment(comment);
            Data.UserCommentDic[Data.CurrentlyLogedUser].Add(comment);

            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            
            var issues = Data.UserIssueDic[Data.CurrentlyLogedUser.UserName];
            if (!issues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, issues
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (Data.CurrentlyLogedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }
         
            var comments = Data.UserCommentDic[this.Data.CurrentlyLogedUser];



            //PERFORAMNCE            
            if (!comments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, comments);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();

            foreach (var tag in tags)
            {
                issues.AddRange(Data.TagIssueDic[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var newIssue = issues.Distinct();

            if (!newIssue.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine,
                newIssue.OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Title));
        }
    }
}