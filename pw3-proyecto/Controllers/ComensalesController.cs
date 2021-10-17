using Microsoft.AspNetCore.Mvc;

namespace pw3_proyecto.Controllers
{
    public class ComensalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservas()
        {
            return View();
        }
    }
}
