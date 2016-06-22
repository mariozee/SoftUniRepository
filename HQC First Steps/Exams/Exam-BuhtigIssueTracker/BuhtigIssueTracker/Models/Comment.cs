namespace BuhtigIssueTracker.Models
{
    using Interfaces;
    using System;
    using System.Text;

    //DI: Added interface IComment
    public class Comment : IComment
    {
        private string text;

        public Comment(IUser author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public IUser Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder().
                AppendLine(Text).
                AppendFormat("-- {0}", Author.UserName).
                AppendLine().
                ToString().
                Trim();
        }
    }
}
