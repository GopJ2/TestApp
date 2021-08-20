using System.Collections.Generic;
using TestApp.Data.Entity.Base;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.Entity.Users
{
    public class AppUser: BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Test> Tests { get; set; }
    }
}
