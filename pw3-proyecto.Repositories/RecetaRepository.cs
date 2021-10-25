using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Receta> GetAllByChef(int id)
        {
            return _dbContext.Recetas.Where(recipe => recipe.IdCocinero == id).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Receta FindById(int id)
        {
            return _dbContext.Recetas.Find(id);
        }
    }
}
