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
        private IReservaService _reservaService;
        private IEventoService _eventoService;


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
            List<Evento> eventos= _eventoService.EventAvailable();
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
                if(comensalesAvailable >= confirmarReserva.CantidadComensales)
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
