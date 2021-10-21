using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        
        public List<Evento> EventAvailable();
        public void Save(Evento evento);
        public List<Evento> GetAllBy(int userId);
        public void SaveChanges();
    }
}
