namespace BuhtigIssueTracker.Test
{
    using Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;

    [TestClass]
    public class SearchForIssueTest
    {
        [TestMethod]
        public void SearchForIssue_SeveralTagsProvided_ShouldBeIncludetOnlyOnce()
        {
            string userName = "User";
            string password = "Password";
            string title = "Title";
            string discription = "Issue discription";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1", "tags2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);
            string resultMessage = tracker.SearchForIssues(tags);

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(title)
                .AppendLine("Priority: *")
                .AppendLine(discription)
                .Append("Tags: " + tags[0] + "," + tags[1]);

            Assert.AreEqual(resultMessage, expectedOutput.ToString());
        }

        [TestMethod]
        public void SearchForIssue_NoIssueMatching_ShouldReturNegativeMessage()
        {
            string userName = "User";
            string password = "Password";
            string title = "Title";
            string discription = "Issue discription";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1", "tag2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);
            string[] searchedTags = new string[0];
            string resultMessage = tracker.SearchForIssues(searchedTags);
            string expectedOutput = "There are no issues matching the tags provided";

            Assert.AreEqual(resultMessage, expectedOutput);
        }

        [TestMethod]
        public void SearchForIssue_NoTagsProvided_ShouldReturNegativeMessage()
        {
            string userName = "User";
            string password = "Password";
            string title = "Title";
            string discription = "Issue discription";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1", "tag2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);
            string[] searchedTags = new string[0];
            string resultMessage = tracker.SearchForIssues(searchedTags);
            string expectedOutput = "There are no tags provided";

            Assert.AreEqual(resultMessage, expectedOutput);
        }
    }
}
