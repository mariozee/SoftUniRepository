﻿namespace LearningSystem.Controllers
{
    using Interfaces;
    using Utilities;
    using System;
    using Models;

    public class UsersController : Controller
    {
        public UsersController(IBangaloreUniversityDate data, User user)
        {
            Data = data;
            User = user;
        }
        public View Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("The provided passwords do not match.");
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersData.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(string.Format("A user with username {0} already exists.", username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.UsersData.Add(user);

            return View(user);
        }

        public View Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.UsersData.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(string.Format("A user with username {0} does not exist.", username));
            }

            if (existingUser.Password != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException("The provided password is wrong.");
            }

            this.User = existingUser;

            return View(existingUser);
        }

        public View Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                throw new ArgumentException("The current user is not authorized to perform this operation.");
            }

            var user = this.User;
            this.User = null;
            return View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException("There is already a logged in user.");
            }
        }
    }
}