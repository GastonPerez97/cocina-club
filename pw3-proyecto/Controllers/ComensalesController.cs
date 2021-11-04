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
            EventosCalificaciones eventosCalificaciones = new EventosCalificaciones(_eventoService.GetAllEventosByUser(userId), userId, _eventoService.GetAllEventosByUserCalificacion(userId), _calificacionService.FindCalificacionByUser(userId));
            return View(eventosCalificaciones);
        }

        [HttpPost]
        public IActionResult Reservas(Calificacione calificacione)
        {

            int userId = (int)HttpContext.Session.GetInt32("UserId");

            if (_calificacionService.verifyIfCalificacionExists(calificacione.IdEvento, calificacione.IdComensal) == false)
            {

                if (ModelState.IsValid)
                {
                    _calificacionService.Save(calificacione);
                    TempData["CalificacionOk"] = "¡Calificación agregada correctamente!";
                    return RedirectToAction("Reservas");
                }
                EventosCalificaciones eventosCalificaciones1 = new EventosCalificaciones(_eventoService.GetAllEventosByUser(userId), userId, _eventoService.GetAllEventosByUserCalificacion(userId), _calificacionService.FindCalificacionByUser(userId));

                ViewBag.CalificacionError = "Ocurrió un error al momento de registrar la calificación, intente nuevamente.";
                return View(eventosCalificaciones1);

            }
            EventosCalificaciones eventosCalificaciones2 = new EventosCalificaciones(_eventoService.GetAllEventosByUser(userId), userId, _eventoService.GetAllEventosByUserCalificacion(userId), _calificacionService.FindCalificacionByUser(userId));
            ViewBag.CalificacionError = "Ocurrió un error al momento de registrar la calificación, intente nuevamente.";
            return View(eventosCalificaciones2);

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
