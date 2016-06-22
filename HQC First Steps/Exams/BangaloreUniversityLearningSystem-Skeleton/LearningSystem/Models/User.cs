﻿namespace LearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    public class User
    {
        public User(string username, string password, Role role)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5)
            {
                string message = string.Format("The username must be at least 5 symbols long.");
                throw new ArgumentException(message);
            }
            this.Username = username;

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                string message = string.Format("The password must be at least 6 symbols long.");
                throw new ArgumentException(message);
            }            
            string passwordHash = HashUtilities.HashPassword(password);
            this.Password = passwordHash;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}
