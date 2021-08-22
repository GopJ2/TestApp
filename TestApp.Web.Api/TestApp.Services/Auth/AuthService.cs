using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.DataAccess;
using TestApp.Dto.Auth;
using TestApp.Services.Helper;
using TestApp.Services.Helper.Jwt;

namespace TestApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly GlobalDataAccess _dataAccess;
        
        public AuthService(GlobalDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<TokenDto> LoginAsync(AuthDto model, CancellationToken cancellationToken)
        {
            var user = await _dataAccess._appUserDataAccess.GetUserByFieldAsync(x => x.Email == model.Email, cancellationToken);

            if (user == null || user.Password != PasswordHasherHelper.EncodePassword(model.Password))
            {
                throw new Exception("Invalid credentials");
            }

            return JwtTokenGenerator.GenerateToken(user.Id);
        }
    }
}
