using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Services.Helper
{
    public static class PasswordHasherHelper
    {
        private static readonly byte[] Salt = new byte[128 / 8];
        private const KeyDerivationPrf DerivationPrf = KeyDerivationPrf.HMACSHA1;
        private const int IterationCount = 10000;
        private const int NumBytesRequested = 256 / 8;

        public static string EncodePassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Salt,
                DerivationPrf,
                IterationCount,
                NumBytesRequested)
            );
        }
    }
}
