using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepo;

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
            foreach(int recetaId in recetasId)
            {
                EventosReceta eventoReceta = new EventosReceta();
                eventoReceta.IdEvento = evento.IdEvento;
                eventoReceta.IdReceta = recetaId;

                evento.EventosReceta.Add(eventoReceta);
            }

            _eventoRepo.SaveChanges();
        }

        public List<Evento> EventAvailable()
        {
            return _eventoRepo.EventAvailable();
        }

        public Evento FindById(int id)
        {
            return _eventoRepo.FindById(id);
        }

        public List<Evento> GetAllBy(int userId)
        {
            return _eventoRepo.GetAllBy(userId);
        }
    }
}
