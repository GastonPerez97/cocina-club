using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pw3_proyecto.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
        {
            SelectLayout();
            return View();
        }

        public IActionResult Error()
        {
            SelectLayout();
            return View();
        }

        private void SelectLayout()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var userProfile = HttpContext.Session.GetInt32("Profile");

            if (userId == null)
            {
                ViewBag.Layout = "_LayoutAnonimo";
            }
            else if (userId != null && userProfile == 0)
            {
                ViewBag.Layout = "_LayoutComensal";
            }
            else
            {
                ViewBag.Layout = "_LayoutCocinero";
            }
        }
    }
}
