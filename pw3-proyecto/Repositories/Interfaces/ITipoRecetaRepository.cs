using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface ITipoRecetaRepository
    {
        public List<TipoReceta> GetAll();
        public TipoReceta GetBy(int id);
    }
}
