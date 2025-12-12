
using System;
using UserManagement.Domain.Common;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected User() { } // EF Core

        protected User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");

            Name = name;
            Email = new Email(email);
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string name, string email)
        {
             if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
             Name = name;
             Email = new Email(email);
        }

        public void Deactivate()
        {
            IsActive = false;
        }
        
        public void Activate()
        {
            IsActive = true;
        }

        public abstract string GetRole();
    }
}
