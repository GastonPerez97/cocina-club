using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public interface IEventoRepository
    {
        public void SaveChanges();
        public void Save(Evento evento);
        public List<Evento> GetAllBy(int userId);
        public List<Evento> EventAvailable();


    }
}