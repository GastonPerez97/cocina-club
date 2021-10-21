using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace pw3_proyecto.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private _20212C_TPContext _dbContext;

        public EventoRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Evento> GetAllBy(int userId)
        {
            return _dbContext.Eventos.Where(evento => evento.IdCocinero == userId).ToList();
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
