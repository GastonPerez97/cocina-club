using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using pw3_proyecto.Entities;
using System.Linq;

namespace pw3_proyecto.Filters
{
    public class CocineroAuthorizationFilter : ActionFilterAttribute
    {
        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Filters.OfType<SkipControllerFilterAttribute>().Any())
            {
                return;
            }

            var userProfile = context.HttpContext.Session.GetInt32("Profile");

            if (userProfile == null || userProfile != Profiles.Cocinero)
            {
                context.Result = new RedirectResult("/login");
                await context.Result.ExecuteResultAsync(context);
            }
        }
    }
}
