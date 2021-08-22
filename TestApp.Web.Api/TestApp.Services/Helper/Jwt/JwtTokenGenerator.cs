using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestApp.Dto.Auth;
using TestApp.Dto.Config;

namespace TestApp.Services.Helper.Jwt
{
    public static class JwtTokenGenerator
    {
        public static TokenDto GenerateToken(Guid id)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = JwtConfig.GetSymmetricKey();
            var expiration = DateTime.Now.AddMinutes(JwtConfig.LifeTime);
            var jwtToken = new JwtSecurityToken(
                JwtConfig.Issuer,
                JwtConfig.Audience,
                authClaims,
                expires: expiration,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(authSigningKey),
                    SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new TokenDto
            {
                Token = $"Bearer {token}",
                ExpiresAt = expiration,
            };
        }
    }
}
