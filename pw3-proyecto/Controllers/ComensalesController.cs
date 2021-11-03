using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using pw3_proyecto.Entities.Models;
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
        private readonly ICalificacionService _calificacionService;

        public ComensalesController(IReservaService reservaService, IEventoService eventoService, ICalificacionService calificacionService)
        {
            _reservaService = reservaService;
            _eventoService = eventoService;
            _calificacionService = calificacionService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Reservas");
        }

        public IActionResult Reservas()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            EventosCalificaciones eventosCalificaciones = new EventosCalificaciones(_eventoService.GetAllEventosByUser(userId), userId);
            return View(eventosCalificaciones);
        }

        [HttpPost]
        public IActionResult Reservas(Calificacione calificacione)
        {

            int userId = (int)HttpContext.Session.GetInt32("UserId");
            EventosCalificaciones eventosCalificaciones = new EventosCalificaciones(_eventoService.GetAllEventosByUser(userId), userId);

            if (_calificacionService.FindCalificacionByIdEventoAndIdComensal(calificacione.IdEvento, calificacione.IdComensal) == null)
            {

                if (ModelState.IsValid)
                {
                    _calificacionService.Save(calificacione);
                    return RedirectToAction("Reservas");
                }
                else
                {

                    return View(calificacione);

                }
            }

            return View(eventosCalificaciones);

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
