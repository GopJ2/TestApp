using Microsoft.EntityFrameworkCore;
using System;
using TestApp.Data.Seeders.Helper;

namespace TestApp.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void SeedDataBase(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.GenerateUsers();
            modelBuilder.GenerateTests();
            modelBuilder.GenerateQuestions();
            modelBuilder.GenerateAnswers();
        }

    }
}
