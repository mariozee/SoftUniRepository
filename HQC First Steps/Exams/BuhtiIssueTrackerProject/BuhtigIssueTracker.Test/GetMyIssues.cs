using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuhtigIssueTracker.Models;

namespace BuhtigIssueTracker.Test
{
    [TestClass]
    public class GetMyIssues
    {
        [TestMethod]
        public void GetMyIssues_IssuePrint_ShouldReturnIssuesByCurrentUser()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue("IssueTitle", "Discription",
                IssuePrority.Medium, new string[] { "issue" });
            string myIssues = tracker.GetMyIssues();

            var issue = new Issue("IssueTitle", "Discription",
                IssuePrority.Medium, new List<string> { "issue" });

            Assert.AreEqual(issue.ToString(), myIssues);
        }

        [TestMethod]
        public void GetMyIssues_IssuePrint_ShouldReturnOrderedIssueString()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue("IssueTitle", "Discription",
                IssuePrority.Medium, new string[] { "issue" });

            tracker.CreateIssue("IssueTitle2", "Discription",
                IssuePrority.High, new string[] { "issue" });

            tracker.CreateIssue("AnotherIssue", "Discription",
                IssuePrority.Low, new string[] { "issue" });


            string myIssues = tracker.GetMyIssues();

            var issues = new List<Issue>()
            {
                new Issue("IssueTitle2", "Discription",
                IssuePrority.High, new List<string> { "issue" }),
                new Issue("IssueTitle", "Discription",
                IssuePrority.Medium, new List<string> { "issue" }),
                new Issue("AnotherIssue", "Discription",
                IssuePrority.Low, new List<string> { "issue" })
            };
            DateTime
            Assert.AreEqual(string.Join(Environment.NewLine, issues), myIssues);
        }
    }
}
