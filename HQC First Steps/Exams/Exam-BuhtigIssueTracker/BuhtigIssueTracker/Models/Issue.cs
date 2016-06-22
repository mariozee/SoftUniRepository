namespace BuhtigIssueTracker.Models
{
    using Interfaces;
    using Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    ////DI: Added IIssue interface
    public class Issue : IIssue
    {
        private string title;
        private string description;

        public Issue(string title, string description, IssuePrioritetType priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            ////FIX: instantiation Comments in constructor
            this.Comments = new List<IComment>();
        }

        public int Id { get; set; }

        public IssuePrioritetType Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IList<IComment> Comments { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("The title must be at least 3 symbols long");
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The description must be at least 5 symbols long");
                }

                this.description = value;
            }
        }

        public void AddComment(IComment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();
            issue.AppendLine(this.Title).
                AppendFormat("Priority: {0}", this.GetPriorityAsString()).
                AppendLine().AppendLine(this.Description);

            if (this.Tags.Count > 0)
            {
                issue.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issue.AppendFormat("Comments:{0}{1}", 
                    Environment.NewLine, 
                    string.Join(Environment.NewLine, this.Comments)).AppendLine();
            }

            return issue.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePrioritetType.Showstopper:
                    return "****";
                case IssuePrioritetType.High:
                    return "***";
                case IssuePrioritetType.Medium:
                    return "**";
                case IssuePrioritetType.Low:
                    return "*";
                default:
                    throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}
