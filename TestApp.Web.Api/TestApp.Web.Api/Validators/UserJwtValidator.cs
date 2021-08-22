using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.DataAccess;

namespace TestApp.Web.Api.Validators
{
    public class UserJwtValidator : JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            try
            {
                var dataAccess = context.HttpContext.RequestServices.GetRequiredService<GlobalDataAccess>();
                var id = context.Principal?.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (id == null)
                {
                    context.Fail("invalid_token");
                }

                var checkUser =
                    await dataAccess._appUserDataAccess.GetUserByFieldAsync(x => x.Id == id, new CancellationToken());

                if ( checkUser == null )
                {
                    context.Fail("invalid_token");
                }
                else
                {
                    context.Success();
                }
            }
            catch ( Exception e )
            {
                context.Fail(e.Message);
            }
        }
    }
}
