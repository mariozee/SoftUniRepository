﻿namespace AirConditionerTesting.Exceptions
{
    using System;

    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException(string message) : base(message)
        {
        }
    }
}
