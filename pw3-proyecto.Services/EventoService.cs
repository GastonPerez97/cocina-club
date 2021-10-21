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
    public class EventoService : IEventoService
    {
        private IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        
        public void Register(Evento evento)
        {
            _eventoRepository.Register(evento);
        }

        public List<Evento> EventAvailable()
        {
            return _eventoRepository.EventAvailable();
        }
    }
}
