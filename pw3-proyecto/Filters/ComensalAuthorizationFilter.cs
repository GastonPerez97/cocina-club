using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using pw3_proyecto.Entities;

namespace pw3_proyecto.Filters
{
    public class ComensalAuthorizationFilter : ActionFilterAttribute
    {
        public async override void OnActionExecuting(ActionExecutingContext context)
        {
            var userProfile = context.HttpContext.Session.GetInt32("Profile");

            if (userProfile == null || userProfile != Profiles.Comensal)
            {
                context.Result = new RedirectResult("/login");
                await context.Result.ExecuteResultAsync(context);
            }
        }
    }
}
