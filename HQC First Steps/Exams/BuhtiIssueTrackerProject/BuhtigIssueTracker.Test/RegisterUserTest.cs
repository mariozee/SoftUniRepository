using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuhtigIssueTracker.Test
{    
    [TestClass]
    public class RegisterUserTest
    {
        [TestMethod]
        public void RegisterUser_Success_ShouldReturnApprovalMessage()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            string message = tracker.RegisterUser(userName, password, password);
            string expectedMessage = string.Format("User {0} registered successfully", userName);

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void RegisterUser_NotMatchingPassowrds_ShouldReturnNegativeMessage()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            string wrongPassword = "wrongpass";
            string message = tracker.RegisterUser(userName, password, wrongPassword);
            string expectedMessage = "The provided passwords do not match";

            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void RegisterUser_TakenUserName_ShouldReturnNegativeMessage()
        {
            var tracker = new IssueTracker();
            string userName = "Username";
            string password = "password";
            tracker.RegisterUser(userName, password, password);
            string message = tracker.RegisterUser(userName, password, password);
            string expectedMessage = "A user with username Username already exists";

            Assert.AreEqual(expectedMessage, message);
        }
    }
}
