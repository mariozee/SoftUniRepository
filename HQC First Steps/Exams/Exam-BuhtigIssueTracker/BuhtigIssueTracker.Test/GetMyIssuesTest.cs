namespace BuhtigIssueTracker.Test
{
    using Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Text;

    [TestClass]
    public class GetMyIssuesTest
    {
        [TestMethod]
        public void GetMyIssue_GettingCurrentUserIssues_ShouldReturnUserIssues()
        {
            string userName = "User";
            string password = "Password";
            string title = "Title";
            string discription = "Issue discription";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);

            string issueMessage = tracker.GetMyIssues();

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(title)
                .AppendLine("Priority: *")
                .AppendLine(discription)
                .Append("Tags: " + tags[0]);

            Assert.AreEqual(issueMessage, expectedOutput.ToString());
        }

        [TestMethod]
        public void GetMyIssue_NoIssues_ShouldReturnNegativeMesasge()
        {
            string userName = "User";
            string password = "Password";

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);

            string issueMessage = tracker.GetMyIssues();
            string expectedOutput = "No issues";
            Assert.AreEqual(issueMessage, expectedOutput);
        }
    }
}
