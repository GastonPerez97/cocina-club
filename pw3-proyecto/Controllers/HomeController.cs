using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Controllers
{
	public class HomeController : Controller
	{
        private readonly IEventoService _eventoService;

        public HomeController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public IActionResult Index()
        {
            SelectLayout();

            List<Evento> finishedEvents = _eventoService.GetFinishedEvents();

            if (finishedEvents.Count >= 6)
                finishedEvents = finishedEvents.GetRange(0, 6);

            return View(finishedEvents);
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
            else if (userId != null && userProfile == Profiles.Comensal)
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
