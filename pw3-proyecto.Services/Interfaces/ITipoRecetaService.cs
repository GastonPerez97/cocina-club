using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface ITipoRecetaService
    {
        public List<TipoReceta> GetAll();
        public bool CheckIfTipoRecetaExists(int id);
    }
}
