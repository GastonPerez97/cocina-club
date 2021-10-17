using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Repositories
{
    public class TipoRecetaRepository : ITipoRecetaRepository
    {
        private _20212C_TPContext _dbContext;

        public TipoRecetaRepository(_20212C_TPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TipoReceta> GetAll()
        {
            return _dbContext.TipoRecetas.OrderBy(o => o.Nombre).ToList();
        }

        public TipoReceta GetBy(int id)
        {
            return _dbContext.TipoRecetas.Find(id);
        }
    }
}
