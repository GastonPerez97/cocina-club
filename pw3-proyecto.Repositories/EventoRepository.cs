using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
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

        public List<Evento> EventAvailable()
        {
            var query = from e in _dbContext.Eventos
                        where e.Fecha > DateTime.Now
                        && e.CantidadComensales > 0
                        select e;

            return query.ToList();
        }

        public Evento FindById(int id)
        {
            return _dbContext.Eventos.Find(id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
