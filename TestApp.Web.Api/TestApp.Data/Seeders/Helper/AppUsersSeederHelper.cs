using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.Seeders.Helper
{
    public static class AppUsersSeederHelper
    {
        public static void GenerateUsers(this ModelBuilder modelBuilder)
        {
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
