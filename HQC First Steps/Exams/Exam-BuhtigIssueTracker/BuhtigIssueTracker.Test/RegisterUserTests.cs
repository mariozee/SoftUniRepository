namespace BuhtigIssueTracker.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class RegisterUserTests
    {
        [TestMethod]
        public void RegisterUser_EmptyDictionary_ShouldRegisterUserAndAddToData()
        {
            string userName = "correctUsername";
            string password = "correctPassword";

            var tracker = new CommandExecuter();
            string result = tracker.RegisterUser(userName, password, password);

            Assert.AreEqual("User correctUsername registered successfully", result);
            Assert.AreEqual(1, tracker.Data.UsersData.Count);
            var user = tracker.Data.UsersData.First().Key;
            Assert.AreEqual(user, userName);
        }

        [TestMethod]
        public void RegisterUser_NotMatchingPasswords_ReturnsMessages()
        {
            string userName = "correctUsername";
            string password = "correctPassword";
            string incorectPassword = "incorectPassword";

            string expectedMessage = "The provided passwords do not match";
            var tracker = new CommandExecuter();
            string result = tracker.RegisterUser(userName, password, incorectPassword);

            Assert.AreEqual(result, expectedMessage);
        }

        [TestMethod]
        public void RegisterUser_UsernameAlreadyTaken_ReturnsMessages()
        {
            string userName = "takenUserName";
            string password = "correctPassword";

            string expectedMessage = "A user with username takenUserName already exists";
            var tracker = new CommandExecuter();
            tracker.RegisterUser(userName, password, password);
            string result = tracker.RegisterUser(userName, password, password);

            Assert.AreEqual(result, expectedMessage);
        }
    }
}
