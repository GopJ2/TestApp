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
                    Id = "f14f0184-0b15-431f-b4e3-853224eed6dd",
                    UserId = "a8a4828c-60f0-4f99-bbe6-229df1d098a2",
                    Description = "Sample C# Tests",
                },

                new Test
                {
                    Id = "91b1aa6d-bd4a-43e0-ad89-e672709e35fe",
                    UserId = "ce40ea29-e665-4a37-858b-e7d2359cdd4f",
                    Description = "Sample LINQ Tests",
                }
            }.ForEach(x => modelBuilder.Entity<Test>().HasData(x));
        }
    }
}
