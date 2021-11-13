using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IEventoService
    {
        public void Save(Evento evento);
        public void LinkRecipesToEvent(Evento evento, List<int> recetasId);
        public List<Evento> GetAllBy(int userId);
        public List<Evento> getAvailableEventsOf(int userId);
        public Evento FindById(int id);
        public int ComensalesAvailable(int IdEvento);
        public List<Evento> GetAllEventosByUser(int idUser);
        public List<Evento> GetAllEventosByUserCalificacion(int idUser);
        public List<Evento> GetFinishedEvents();
        public void ChangeEventStateTo(int eventState, int eventId);
        public bool CheckIfEventBelongsToUser(int eventId, int userId);
        public void CancelEvent(int eventId);

    }
}