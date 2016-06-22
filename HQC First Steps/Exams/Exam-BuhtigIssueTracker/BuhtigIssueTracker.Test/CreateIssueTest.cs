namespace BuhtigIssueTracker.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using Enum;

    [TestClass]
    public class CreateIssueTest
    {
        [TestMethod]
        public void CreateIssue_IssueAddingToData_ShouldReturnPositiveMessage()
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

            string output = tracker.CreateIssue(title, discription, priority, tags);
            string expectedOutput = "Issue 1 created successfully";

            Assert.AreEqual(output, expectedOutput);
        }

        [TestMethod]
        public void CreateIssue_AddingAouthorToIssue_ShouldAssigneCurrentUserAsAuthor()
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
            string user = tracker.Data.UsernameIssueData.First().Key;

            Assert.AreEqual(user, userName);
        }

        [TestMethod]
        public void CreateIssue_CreatingId_IssueShouldGetIdAutomatically()
        {
            const int FirstIssueId = 1;
            const int SecondIssueId = 2;

            string userName = "User";
            string password = "Password";
            string firstIssueTitle = "Title 1";
            string firstIssueDiscription = "Issue discription 1";
            IssuePrioritetType firstIssuePriority = IssuePrioritetType.Low;
            string[] firstIssueTags = new string[] { "tag1", "tag2" };

            string secondIssueTitle = "Title 2";
            string secondIssueDiscription = "Issue discription 2";
            IssuePrioritetType secondIssuePriority = IssuePrioritetType.Low;
            string[] secondIssueTags = new string[] { "tag1", "tag2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(firstIssueTitle, firstIssueDiscription, firstIssuePriority, firstIssueTags);
            tracker.CreateIssue(secondIssueTitle, secondIssueDiscription, secondIssuePriority, secondIssueTags);

            var firstIssue = tracker.Data.IdIssueData.First();
            var secondIssue = tracker.Data.IdIssueData.Last();

            Assert.AreEqual(firstIssue.Key, FirstIssueId);
            Assert.AreEqual(secondIssue.Key, SecondIssueId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_GivingInvalidTitleLenght_ShouldThrowException()
        {
            string userName = "User";
            string password = "Password";
            string title = "tt";
            string discription = "Issue discription";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1", "tag2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_GivingInvalidDiscriptionLenght_ShouldThrowException()
        {
            string userName = "User";
            string password = "Password";
            string title = "Title";
            string discription = "Desc";
            IssuePrioritetType priority = IssuePrioritetType.Low;
            string[] tags = new string[] { "tag1", "tag2" };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title, discription, priority, tags);
        }

        [TestMethod]
        public void CreateIssue_NonRepeatableTags_MustContainCurrentTagOnlyOnes()
        {
            const string tag = "nonRepeatable";

            string userName = "User";
            string password = "Password";

            string title1 = "Title";
            string discription1 = "Issue discription";
            IssuePrioritetType priority1 = IssuePrioritetType.Low;
            string[] tags1 = new string[] { tag };

            string title2 = "Title2";
            string discription2 = "Issue discription2";
            IssuePrioritetType priority2 = IssuePrioritetType.Low;
            string[] tags2 = new string[] { tag };

            string title3 = "Title3";
            string discription3 = "Issue discription3";
            IssuePrioritetType priority3 = IssuePrioritetType.Low;
            string[] tags3 = new string[] { tag };

            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue(title1, discription1, priority1, tags1);
            tracker.CreateIssue(title2, discription2, priority2, tags2);
            tracker.CreateIssue(title3, discription3, priority3, tags3);

            int tagsCount = tracker.Data.TagIssueData.Keys.Count;

            Assert.AreEqual(tagsCount, 1);
        }
    }
}
