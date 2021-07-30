using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistrationRegex
{
    class UserRegCustomException : Exception
    {
        public enum ExceptionType
        {
            ENTERED_NULL, ENTERED_NUMBER,
            FIRST_CAPITAL, MIN_THREE, EMPTY,
            INVALID_EMAIL, INVALID_PHONE_NUMBER,
            INVALID_PASSWORD
        }
        public readonly ExceptionType type;
        public string message;
        public UserRegCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
