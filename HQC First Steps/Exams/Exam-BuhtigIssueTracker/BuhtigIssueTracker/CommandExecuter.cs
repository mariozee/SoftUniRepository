namespace BuhtigIssueTracker
{
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using Enum;

    public class CommandExecuter : IIssueTracker
    {
        CommandExecuter(IBuhtigIssueTrackerData data)
        {
           // Data = data as Data;
            this.Data = new Data();
        }

        public CommandExecuter()
            : this(new Data())
        {
        }

        public Data Data { get; set; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            //FIX: change == to !=
            if (Data.CurrentlyLoggedUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (Data.UsersData.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);

            Data.UsersData.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (Data.CurrentlyLoggedUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (!Data.UsersData.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = Data.UsersData[username];

            if (user.PasswordHash != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            Data.CurrentlyLoggedUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = Data.CurrentlyLoggedUser.UserName;
            Data.CurrentlyLoggedUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(
            string title,
            string description,
            IssuePrioritetType priority,
            string[] tags)
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            Data.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!Data.IdIssueData.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = Data.IdIssueData[issueId];
            if (!Data.UsernameIssueData[Data.CurrentlyLoggedUser.UserName].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.Data.CurrentlyLoggedUser.UserName);
            }

            this.Data.RemoveIssue(issue);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string commentText)
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            //FIX: change (commentId + 1) to (commentId)
            if (!Data.IdIssueData.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = Data.IdIssueData[issueId];
            var comment = new Comment(Data.CurrentlyLoggedUser, commentText);
            issue.AddComment(comment);
            Data.UserCommentData[Data.CurrentlyLoggedUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issues = Data.UsernameIssueData[Data.CurrentlyLoggedUser.UserName];

            //PERFORMANNCE: Unnedded operations, string concatenation in a loop
            if (!issues.Any())
            { 
                return "No issues";
            }
            var orderedIssues = issues.OrderByDescending(x => x.Priority).
                ThenBy(x => x.Title);

            return string.Join(Environment.NewLine, orderedIssues);
        }

        public string GetMyComments()
        {
            if (Data.CurrentlyLoggedUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            //PERFORAMCE: Values ware not retrived form the correct dictionayr
            var comments = this.Data.UserCommentData[this.Data.CurrentlyLoggedUser];
            if (!comments.Any())
            {
                return "No comments";
            }

            var commentsAsStrings = comments.Select(c => c.ToString());
            return string.Join(Environment.NewLine, commentsAsStrings);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<IIssue>();

            foreach (var tag in tags)
            {
                issues.AddRange(Data.TagIssueData[tag]);
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
                newIssue.OrderByDescending(x => x.Priority).
                ThenBy(x => x.Title).
                Select(x => x.ToString()));
        }
    }
}
