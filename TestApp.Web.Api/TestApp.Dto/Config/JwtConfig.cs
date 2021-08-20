using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Dto.Config
{
    public class JwtConfig
    {
        public const string Issuer = "TestAppIssuer";
        public const string Audience = "TestAppAudience";
        private static string SecretKey { get; set; } = "TestAppSecretKey";

        public const double LifeTime = 60;

        public static byte[] GetSymmetricKey()
        {
            return Encoding.UTF8.GetBytes(SecretKey);
        }
    }
}
