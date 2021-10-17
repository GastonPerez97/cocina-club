using Microsoft.AspNetCore.Mvc;

namespace pw3_proyecto.Controllers
{
    public class CocineroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}
