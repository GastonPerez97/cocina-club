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

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
