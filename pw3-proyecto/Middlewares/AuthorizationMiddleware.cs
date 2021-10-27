using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace pw3_proyecto.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            string pathLowercase = path.ToString().ToLower();

            if (path.HasValue)
            {
                if (pathLowercase.StartsWith("/cocineros") && httpContext.Session.GetInt32("Profile") != 1)
                {
                    httpContext.Response.Redirect("/login");
                }

                if (pathLowercase.StartsWith("/comensales") && httpContext.Session.GetInt32("Profile") != 0)
                {
                    httpContext.Response.Redirect("/login");
                }
            }

            return _next(httpContext);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
