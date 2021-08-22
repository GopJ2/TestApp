using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace TestApp.Web.Api.Helpers
{
    public static class GetAppUserFromContext
    {
        public static string GetUserId(this HttpContext context)
        {
            var userId = context?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new NullReferenceException("No user associated with token");
            }
            
            return userId;
        }
    }
}