using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;

namespace pw3_proyecto.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private _20212C_TPContext _dbContext;

        public EventoRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
