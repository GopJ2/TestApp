using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Data.Entity.Tests;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.Seeders.Helper
{
    public static class TestsSeederHelper
    {
        public static void GenerateTests(this ModelBuilder modelBuilder)
        {
            new List<Test>()
            {
                new Test
                {
                    Id = Guid.Parse("f14f0184-0b15-431f-b4e3-853224eed6dd"),
                    Name = "C# Test",
                    UserId = Guid.Parse("ce40ea29-e665-4a37-858b-e7d2359cdd4f"),
                    Description = "Sample C# Tests Description",
                },
                new Test
                {
                    Id = Guid.Parse("b5902bf9-bea2-4fac-96bc-52c0ed52e6c7"),
                    UserId = Guid.Parse("ce40ea29-e665-4a37-858b-e7d2359cdd4f"),
                    Name = "Node.js Test",
                    Description = "Sample Node.js Tests",
                },
                new Test
                {
                    Id = Guid.Parse("91b1aa6d-bd4a-43e0-ad89-e672709e35fe"),
                    Name = "LINQ Test",
                    UserId = Guid.Parse("a8a4828c-60f0-4f99-bbe6-229df1d098a2"),
                    Description = "Sample LINQ Tests",
                },
                 new Test
                {
                    Id = Guid.Parse("c23f9ea6-50a9-417c-89bb-15194cc2787b"),
                    Name = "Vanilla JS Test",
                    UserId = Guid.Parse("a8a4828c-60f0-4f99-bbe6-229df1d098a2"),
                    Description = "Sample Javascript Tests",
                },
            }.ForEach(x => modelBuilder.Entity<Test>().HasData(x));
        }
    }
}
