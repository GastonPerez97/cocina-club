using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Filters;
using pw3_proyecto.Services.Common.CustomExceptions;
using pw3_proyecto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace pw3_proyecto.Controllers
{
    [CocineroAuthorizationFilter]
    public class CocinerosController : Controller
    {
        private readonly ITipoRecetaService _tipoRecetaService;
        private readonly IRecetaService _recetaService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IEventoService _eventoService;
        private readonly IWebHostEnvironment _hostingEnv;

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
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            List<Receta> recipes = _recetaService.GetAllByChef(userId);
            List<Evento> eventos = _eventoService.GetAllBy(userId);

            ViewBag.User = _userService.GetBy(userId);
            ViewBag.Events = eventos;
            ViewBag.EventCount = eventos.Count;
            ViewBag.Recipes = recipes;
            ViewBag.RecipeCount = recipes.Count;

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

        public IActionResult Eventos()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.ChefRecipes = _recetaService.GetAllByChef(ViewBag.UserId);
            return View();
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

        [SkipControllerFilterAttribute]
        [Route("evento/{id}")]
        public IActionResult Evento(int id)
        {
            Evento evento = _eventoService.FindById(id);

            if (evento == null)
                return RedirectToAction("Index", "Home");

            SelectLayout();
            return View(evento);
        }

        [HttpPost]
        public IActionResult FinalizarEvento()
        {
            try
            {
                int eventId = int.Parse(Request.Form["IdEvento"]);
                int currentUserId = (int)HttpContext.Session.GetInt32("UserId");

                if (_eventoService.CheckIfEventBelongsToUser(eventId, currentUserId))
                {
                    _eventoService.ChangeEventStateTo(EventStates.Finalizado, eventId);
                    TempData["FinalizeEventOk"] = "Evento finalizado correctamente.";
                }
                else
                {
                    TempData["FinalizeEventError"] = "Ocurrió un error al intentar finalizar el evento, intente nuevamente.";
                }

                return RedirectToAction("Perfil");
            }
            catch (Exception)
            {
                TempData["FinalizeEventError"] = "Ocurrió un error al intentar finalizar el evento, intente nuevamente.";
                return RedirectToAction("Perfil");
            }
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

        private void SelectLayout()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var userProfile = HttpContext.Session.GetInt32("Profile");

            if (userId == null)
            {
                ViewBag.Layout = "_LayoutAnonimo";
            }
            else if (userId != null && userProfile == Profiles.Comensal)
            {
                ViewBag.Layout = "_LayoutComensal";
            }
            else
            {
                ViewBag.Layout = "_LayoutCocinero";
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CancelarEvento(int IdEvento)
        //{

        //    Evento evento = _eventoService.FindById(IdEvento);


        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44381/");

        //    HttpResponseMessage response = await client.PutAsJsonAsync($"api/Event/{evento.IdEvento}", evento);
            
        //    evento = await response.Content.ReadFromJsonAsync<Evento>();

        //    return RedirectToAction("Perfil");
        //}

    }
}
