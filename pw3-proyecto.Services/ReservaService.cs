using pw3_proyecto.Entities;
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
        private IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public void Save(Reserva reservation)
        {
            _reservaRepository.Save(reservation);
            _reservaRepository.SaveChanges();
        }
        public List<Reserva> ReservasDisponibles()
        {
            return _reservaRepository.ReservasDisponibles();
        }
    }
}
