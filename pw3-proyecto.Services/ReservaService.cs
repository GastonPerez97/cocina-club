using pw3_proyecto.Entities;
using pw3_proyecto.Entities.Model;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IRecetaService _recetaService;
        private readonly IEventoService _eventoService;

        public ReservaService(IReservaRepository reservaRepository, IEventoService eventoService, IRecetaService recetaService)
        {
            _reservaRepository = reservaRepository;
            _recetaService = recetaService;
            _eventoService = eventoService;
        }

        public ConfirmarReserva details(int idE, int idC)
        {
            ConfirmarReserva confirmarReserva = new ConfirmarReserva();
            List<Receta> recetasEvento = new List<Receta>();
            Evento evento = _eventoService.FindById(idE);
           
            foreach (var a in evento.EventosReceta)
            {
                recetasEvento.Add(_recetaService.FindById(a.IdReceta));
            }
            confirmarReserva.IdEvento = evento.IdEvento;
            confirmarReserva.IdComensal = idC;
            confirmarReserva.recetas = recetasEvento;
            confirmarReserva.CantidadComensales = evento.CantidadComensales;

            return confirmarReserva;
        }

        public void Save(Reserva reservation)
        {
            _reservaRepository.Save(reservation);
            _reservaRepository.SaveChanges();
        }

        public void SaveReserva(ConfirmarReserva confirmarReserva)
        {
            Reserva reserva = new Reserva();
            reserva.FechaCreacion = DateTime.Now;
            reserva.IdComensal = confirmarReserva.IdComensal;
            reserva.IdEvento = confirmarReserva.IdEvento;
            reserva.IdReceta = confirmarReserva.IdRecetaElegida;
            reserva.CantidadComensales = confirmarReserva.CantidadComensales;
            
            Evento evento = _eventoService.FindById(confirmarReserva.IdEvento);
            evento.CantidadComensales = (evento.CantidadComensales - confirmarReserva.CantidadComensales);
           
            this.Save(reserva);

        }
    }
}
