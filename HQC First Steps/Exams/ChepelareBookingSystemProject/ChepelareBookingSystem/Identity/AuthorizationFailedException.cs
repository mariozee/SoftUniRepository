﻿using ChepelareBookingSystem.Models;
using System;

namespace ChepelareBookingSystem.Identity
{
    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
