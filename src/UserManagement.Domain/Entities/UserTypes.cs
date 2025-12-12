
namespace UserManagement.Domain.Entities
{
    public class AdminUser : User
    {
        public AdminUser(string name, string email) : base(name, email)
        {
        }

        private AdminUser() { } // EF Core

        public override string GetRole()
        {
            return "Admin";
        }
    }

    public class StandardUser : User
    {
        public StandardUser(string name, string email) : base(name, email)
        {
        }

        private StandardUser() { } // EF Core

        public override string GetRole()
        {
            return "Standard";
        }
    }
}
