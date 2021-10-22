using Microsoft.AspNetCore.Mvc;

namespace pw3_proyecto.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Error()
        {
            return View();
        }
	}
}
