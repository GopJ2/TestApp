using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace TestApp.Web.Api.Helpers
{
    public static class GetAppUserFromContext
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var userId = context?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new NullReferenceException("No user associated with token");
            }

            if (Guid.TryParse(userId, out var id))
            {
                return id;
            }

            throw new BadHttpRequestException("Can't parse guid");
        }
    }
}