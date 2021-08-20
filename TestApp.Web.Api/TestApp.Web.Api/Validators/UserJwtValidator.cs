﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                var repository = context.HttpContext.RequestServices.GetRequiredService<GlobalDataAccess>();
                var email = context.Principal?.Claims.First(c => c.Type == ClaimTypes.Email)?.Value;

                if (email == null)
                {
                    context.Fail("invalid_token");
                }

                var checkUser =
                    await repository._appUserDataAccess.GetUserByFieldAsync(x => x.Email == email, new CancellationToken());

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