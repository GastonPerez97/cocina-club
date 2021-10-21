using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private _20212C_TPContext _dbContext;
        public EventoRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Evento> EventAvailable()
        {
            var query = from e in _dbContext.Eventos
                        where e.Fecha > DateTime.Now
                        && e.CantidadComensales > 0
                        select e;

            return query.ToList();
        }

        public void Register(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();
        }
    }
}
