using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Data.Entity.Tests;
using TestApp.Data.Entity.Users;
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

            List<AppUser> users = new List<AppUser>()
            {
                new AppUser()
                {
                    Id = "ce40ea29-e665-4a37-858b-e7d2359cdd4f",
                    Email = "TestUser@gmail.com",
                    Password = HashPassword("Admin@2021"),
                },

                new AppUser()
                {
                    Id = "a8a4828c-60f0-4f99-bbe6-229df1d098a2",
                    Email = "TestUser2@gmail.com",
                    Password = HashPassword("Admin@2021"),
                }
            };

            users.ForEach(x => {
                modelBuilder.Entity<AppUser>().HasData(x);
            });

            modelBuilder.GenerateTests();
            modelBuilder.GenerateQuestions();
            modelBuilder.GenerateAnswers();
        }

        private static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            KeyDerivationPrf derivationPrf = KeyDerivationPrf.HMACSHA1;
            int iterationCount = 10000;
            int numBytesRequested = 256 / 8;

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                derivationPrf,
                iterationCount,
                numBytesRequested)
            );
        }
    }
}
