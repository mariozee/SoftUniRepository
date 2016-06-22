using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningSystem.Models;
using LearningSystem.Controllers;
using LearningSystem.Data;

namespace LearningSystem.Test
{
    [TestClass]
    public class ControllersTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LogoutTest_NoLogedInUser_ShouldThrowExcpetion()
        {
            var data = new BangaloreUniversityDate();
            var userController = new UsersController(data, null);
            var view = userController.Logout();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LogoutTest_GuestUser_ShouldThrowExcpetion()
        {
            var data = new BangaloreUniversityDate();
            var user = new User("GouestUser", "123456", Role.Guest);
            var userController = new UsersController(data, user);
            var view = userController.Logout();
        }

        [TestMethod]
        public void LogoutTest_Success_CurrentUserShouldEqualNull()
        {
            var data = new BangaloreUniversityDate();
            var user = new User("User1", "123456", Role.Lecturer);
            var userController = new UsersController(data, user);
            var view = userController.Logout();

            Assert.IsNull(userController.User);       
        }

        [TestMethod]
        public void AllTest_OrderList_ShouldBeInRightOrder()
        {

        }
    }
}
