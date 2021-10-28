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
        private IEventoRepository _eventoRepo;

        public EventoService(IEventoRepository eventoRepo)
        {
            _eventoRepo = eventoRepo;
        }

        public void Save(Evento evento)
        {
            _eventoRepo.Save(evento);
            _eventoRepo.SaveChanges();
        }

        public void LinkRecipesToEvent(Evento evento, List<int> recetasId)
        {
            foreach (int recetaId in recetasId)
            {
                EventosReceta eventoReceta = new EventosReceta();
                eventoReceta.IdEvento = evento.IdEvento;
                eventoReceta.IdReceta = recetaId;

                evento.EventosReceta.Add(eventoReceta);
            }

            _eventoRepo.SaveChanges();
        }

        public List<Evento> GetAllBy(int userId)
        {
            return _eventoRepo.GetAllBy(userId);
        }
        public List<Evento> EventAvailable()
        {
            return _eventoRepo.EventAvailable();
        }

        public Evento FindById(int id)
        {
            return _eventoRepo.FindById(id);
        }
        public int ComensalesAvailable(int IdEvento)
        {
            int CantidadComensales = 0;
            Evento evento = _eventoRepo.FindEventoReserva(IdEvento);
            foreach(Reserva reserva in evento.Reservas)
            {
                CantidadComensales += reserva.CantidadComensales;
            }
            return (evento.CantidadComensales - CantidadComensales);
        }
        
    }
}
