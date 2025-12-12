
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UserManagement.Domain.Common;

namespace UserManagement.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        private Email() { } // EF Core

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.");

            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format.");

            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            // Simple validation, can be improved
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static explicit operator string(Email email) => email.Value;
        public static explicit operator Email(string email) => new Email(email);
    }
}
