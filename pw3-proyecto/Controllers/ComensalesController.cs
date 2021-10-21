using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Entities;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Controllers
{
    public class ComensalesController : Controller
    {
        private IReservaService _ReservaService;
        private IEventoService _eventoService;

        public ComensalesController(IReservaService reservaService, IEventoService eventoService)
        {
            _ReservaService = reservaService;
            _eventoService = eventoService;
        }

        public IActionResult Index()
        {
            return Redirect("/comensales/reservas");
        }

        public IActionResult Reservas()
        {
            return View();
        }

        public IActionResult Reserva()
        {
            List<Evento> eventos= _eventoService.EventAvailable();
            return View(eventos);
        }
    }
}
