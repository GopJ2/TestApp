using System;
using System.Collections.Generic;
using TestApp.Data.Entity.Base;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.Entity.Tests
{
    public class Test : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TestQuestion> Questions { get; set; }
    }
}
