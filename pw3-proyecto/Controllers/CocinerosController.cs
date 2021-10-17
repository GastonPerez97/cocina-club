using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;

namespace pw3_proyecto.Controllers
{
    public class CocinerosController : Controller
    {
        private ITipoRecetaService _tipoRecetaService;
        private IRecetaService _recetaService;
        private IUserService _userService;

        public CocinerosController(ITipoRecetaService tipoRecetaService,
                                   IRecetaService recetaService,
                                   IUserService userService)
        {
            _tipoRecetaService = tipoRecetaService;
            _recetaService = recetaService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Recetas()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.TipoRecetas = _tipoRecetaService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Recetas(Receta recipe)
        {
            if (ModelState.IsValid
                && _userService.CheckIfUserExists(recipe.IdCocinero)
                && _tipoRecetaService.CheckIfTipoRecetaExists(recipe.IdTipoReceta))
            {
                _recetaService.Save(recipe);
                TempData["RecipeResult"] = "¡La receta fue agregada correctamente!";
            }
            else
            {
                TempData["RecipeResult"] = "Ocurrió un error al intentar crear la receta.";
            }

            return RedirectToAction("Recetas");
        }
    }
}
