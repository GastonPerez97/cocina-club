using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public interface IEventoService
    {
        public void LinkRecipesToEvent(Evento evento, List<int> recetasId);
        public List<Evento> GetAllBy(int userId);
        public void Save(Evento evento);
        public List<Evento> EventAvailable();
    }
}