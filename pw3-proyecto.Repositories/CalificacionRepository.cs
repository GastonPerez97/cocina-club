using Microsoft.EntityFrameworkCore;
using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pw3_proyecto.Repositories
{
    public class CalificacionRepository : ICalificacionRepository
    {

        private readonly _20212C_TPContext _dbContext;

        public CalificacionRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Calificacione calificacione)
        {
            _dbContext.Calificaciones.Add(calificacione);
        }

        public List<Calificacione> FindCalificacionByUser(int idComensal)
        {

            var query = from c in _dbContext.Calificaciones
                        where c.IdComensal == idComensal
                        select c;

            return query != null ? query.ToList() : null;

        }


        public bool verifyIfCalificacionExists(int idEvento, int idComensal)
        {

            bool calificacionEncontrada = false;

            var query = from c in _dbContext.Calificaciones
                        where c.IdEvento == idEvento
                        where c.IdComensal == idComensal
                        select c;

            foreach (Calificacione cal in query)
            {
                calificacionEncontrada = cal != null ? true : false;

            }

            return calificacionEncontrada;

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
