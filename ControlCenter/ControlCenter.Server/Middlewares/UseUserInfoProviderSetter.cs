using ControlCenter.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCenter.Server.Middlewares
{
    public class UseUserInfoProviderSetter
    {
        private readonly RequestDelegate _next;

        public UseUserInfoProviderSetter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserInfoProvider userInfoProvider)
        {
            var idClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var departmentIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "DepartmentId")?.Value;

            if (!string.IsNullOrEmpty(idClaim) && Guid.TryParse(idClaim, out var userId) &&
                !string.IsNullOrEmpty(departmentIdClaim) && Guid.TryParse(departmentIdClaim, out var departmentId))
            {
                userInfoProvider.SetUserInfo(userId, departmentId);
            }

            await _next(httpContext);
        }
    }

    public static class UseUserInfoProviderSetterExtensions
    {
        public static IApplicationBuilder UseUserInfoProviderSetter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UseUserInfoProviderSetter>();
        }
    }
}
