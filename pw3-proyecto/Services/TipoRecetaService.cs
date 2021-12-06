using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public class TipoRecetaService : ITipoRecetaService
    {
        private readonly ITipoRecetaRepository _tipoRecetaRepo;

        public TipoRecetaService(ITipoRecetaRepository tipoRecetaRepo)
        {
            _tipoRecetaRepo = tipoRecetaRepo;
        }

        public List<TipoReceta> GetAll()
        {
            return _tipoRecetaRepo.GetAll();
        }

        public bool CheckIfTipoRecetaExists(int id)
        {
            TipoReceta tipoReceta = _tipoRecetaRepo.GetBy(id);
            return tipoReceta != null ? true : false;
        }
    }
}
