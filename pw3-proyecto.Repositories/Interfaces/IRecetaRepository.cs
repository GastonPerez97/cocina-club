using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IRecetaRepository
    {
        public void Save(Receta recipe);
        public List<Receta> GetAllByChef(int id);
        public void SaveChanges();
    }
}
