using pw3_proyecto.Entities;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        public void Save(Evento evento);
        public void SaveChanges();
    }
}
