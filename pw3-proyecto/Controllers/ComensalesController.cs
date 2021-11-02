using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using pw3_proyecto.Filters;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Controllers
{
    [ComensalAuthorizationFilter]
    public class ComensalesController : Controller
    {
        private readonly IReservaService _reservaService;
        private readonly IEventoService _eventoService;

        public ComensalesController(IReservaService reservaService, IEventoService eventoService)
        {
            _reservaService = reservaService;
            _eventoService = eventoService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Reservas");
        }

        public IActionResult Reservas()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            return View(_eventoService.GetAllEventosByUser(userId));
        }

        [HttpPost]
        public IActionResult Reservas(Calificacione calificacione)
        {

            return View();

        }

        public IActionResult Reserva()
        {
            List<Evento> eventos = _eventoService.EventAvailable();
            return View(eventos);
        }

        public IActionResult Confirmar(string id)
        {
            ConfirmarReserva confirmarReserva = _reservaService.details(int.Parse(id), (int)HttpContext.Session.GetInt32("UserId"));
            ViewBag.ComensalesAvailable = _eventoService.ComensalesAvailable(int.Parse(id));

            return View(confirmarReserva);
        }

        [HttpPost]
        public IActionResult Confirmar(ConfirmarReserva confirmarReserva)
        {
            int comensalesAvailable = _eventoService.ComensalesAvailable(confirmarReserva.IdEvento);
            if (ModelState.IsValid)
            {
                if (comensalesAvailable >= confirmarReserva.CantidadComensales)
                {
                    _reservaService.SaveReserva(confirmarReserva);
                    return RedirectToAction("Reservas");

                }
                else
                    return RedirectToAction("Confirmar", confirmarReserva.IdEvento);
            }

            return RedirectToAction("Reserva");
        }
    }
}
