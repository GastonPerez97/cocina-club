using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Common.CustomExceptions;
using pw3_proyecto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace pw3_proyecto.Controllers
{
    public class CocinerosController : Controller
    {
        private ITipoRecetaService _tipoRecetaService;
        private IRecetaService _recetaService;
        private IUserService _userService;
        private IImageService _imageService;
        private IEventoService _eventoService;
        private IWebHostEnvironment _hostingEnv;

        public CocinerosController(ITipoRecetaService tipoRecetaService,
                                   IRecetaService recetaService,
                                   IUserService userService,
                                   IImageService imageService,
                                   IEventoService eventoService,
                                   IWebHostEnvironment hostingEnv)
        {
            _tipoRecetaService = tipoRecetaService;
            _recetaService = recetaService;
            _userService = userService;
            _imageService = imageService;
            _eventoService = eventoService;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            try
            {
                int userId = (int) HttpContext.Session.GetInt32("UserId");

                List<Receta> recipes = _recetaService.GetAllByChef(userId);
                List<Evento> eventos = _eventoService.GetAllBy(userId);

                ViewBag.User = _userService.GetBy(userId);
                ViewBag.Events = eventos;
                ViewBag.EventCount = eventos.Count;
                ViewBag.Recipes = recipes;
                ViewBag.RecipeCount = recipes.Count;

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }
        }

        public IActionResult Recetas()
        {
            try
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.TipoRecetas = _tipoRecetaService.GetAll();
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }
            
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

        public IActionResult Eventos()
        {
            try
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.ChefRecipes = _recetaService.GetAllByChef(ViewBag.UserId);
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Eventos(Evento evento, IFormFile imageFile)
        {
            evento.Foto = Guid.NewGuid().ToString();
            evento.Estado = EventStates.Pendiente;

            if (ModelState.IsValid)
            {
                try
                {
                    List<int> eventoRecetasId = GetRecipesIdsFromForm();

                    if (eventoRecetasId.Count <= 0)
                    {
                        TempData["EventoRecetasError"] = "Selecciona al menos una de las recetas.";
                        throw new Exception();
                    }

                    _imageService.Save("events", evento.Foto, _hostingEnv.WebRootPath, imageFile);
                    evento.Foto += Path.GetExtension(imageFile.FileName);

                    _eventoService.Save(evento);
                    _eventoService.LinkRecipesToEvent(evento, eventoRecetasId);

                    TempData["EventResult"] = "¡El evento fue creado correctamente!";

                    return RedirectToAction("Eventos");
                }
                catch (ImageNotSavedException)
                {
                    TempData["ImageNotSaved"] = "No se pudo guardar la imagen. Revisa que sea .JPG o .PNG.";
                }
                catch (Exception) { }
            }

            TempData["EventResult"] = "Ocurrió un error al intentar crear el evento.";
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.ChefRecipes = _recetaService.GetAllByChef(ViewBag.UserId);

            return View(evento);
        }

        public List<int> GetRecipesIdsFromForm()
        {
            List<int> eventoRecetasId = new List<int>();

            foreach (var recipeIdString in Request.Form["EventosReceta"])
            {
                int recipeId;
                int.TryParse(recipeIdString, out recipeId);

                eventoRecetasId.Add(recipeId);
            }

            return eventoRecetasId;
        }
    }
}
