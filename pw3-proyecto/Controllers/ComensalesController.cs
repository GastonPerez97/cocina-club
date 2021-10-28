using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Controllers
{
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
            return View();
        }

        public IActionResult Reserva()
        {
            List<Evento> eventos = _eventoService.EventAvailable();
            return View(eventos);
        }

        public IActionResult Confirmar(string id)
        {
            ConfirmarReserva confirmarReserva = _reservaService.details(
                    int.Parse(id),
                    (int) HttpContext.Session.GetInt32("UserId")
                );

            return View(confirmarReserva);
        }

        [HttpPost]
        public IActionResult Confirmar(ConfirmarReserva confirmarReserva)
        {
            if (ModelState.IsValid)
            {
                _reservaService.SaveReserva(confirmarReserva);
                return RedirectToAction("Reservas");
            }

            return RedirectToAction("Reserva");
        }
    }
}
