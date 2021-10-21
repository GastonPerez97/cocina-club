using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public class RecetaService : IRecetaService
    {
        private IRecetaRepository _recetaRepo;

        public RecetaService(IRecetaRepository recetaRepo)
        {
            _recetaRepo = recetaRepo;
        }

        public void Save(Receta receta)
        {
            _recetaRepo.Save(receta);
            _recetaRepo.SaveChanges();
        }

        public List<Receta> GetAllByChef(int id)
        {
            return _recetaRepo.GetAllByChef(id);
        }
    }
}
