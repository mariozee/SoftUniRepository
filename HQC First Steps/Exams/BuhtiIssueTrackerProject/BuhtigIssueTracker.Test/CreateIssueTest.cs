using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuhtigIssueTracker.Models;

namespace BuhtigIssueTracker.Test
{
    [TestClass]
    public class CreateIssueTest
    {
        [TestMethod]
        public void CreateIssue_ValidIssue_ShouldReturnApproavalMassage()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            string message = tracker.CreateIssue("IssueTitle", "Discription", IssuePrority.Medium, new string[] { "issue" });

            Assert.AreEqual("Issue 1 created successfully", message);
        }

        [TestMethod]
        public void CreateIssue_IdIncreasment_ShouldAutomaticIcreaseIssuesId()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            for (int i = 0; i < 9; i++)
            {
                tracker.CreateIssue("IssueTitle", "Discription", IssuePrority.Medium, new string[] { "issue" });
            }

            tracker.CreateIssue("RightIssue", "Discription", IssuePrority.Medium, new string[] { "issue" });

            Assert.AreEqual("RightIssue", tracker.Data.IdIssueDic[10].Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_InvalidTitleLenght_ShouldThrow()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue("Op", "Discription", IssuePrority.Medium, new string[] { "issue" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_InvalidDiscriptionLenght_ShouldThrow()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue("IssueTitle", "Disc", IssuePrority.Medium, new string[] { "issue" });
        }

        [TestMethod]
        public void CreateIssue_DuplicatedTags_ShouldDistinct()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            tracker.LoginUser(userName, password);
            tracker.CreateIssue("IssueTitle", "Discription",
                IssuePrority.Medium, new string[] { "issue", "issue", "new", "new" });

            string output = string.Join(", ", tracker.Data.IdIssueDic[1].Tags);
            DataTime
            Assert.AreEqual(string.Join(", ", new string[] { "issue", "new" }), output);
        }  
    }
}
