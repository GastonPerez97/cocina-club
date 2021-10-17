using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;

namespace pw3_proyecto.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private _20212C_TPContext _dbContext;

        public RecetaRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(Receta recipe)
        {
            _dbContext.Recetas.Add(recipe);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
