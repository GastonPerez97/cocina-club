using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IRecetaService
    {
        public void Save(Receta recipe);
        public List<Receta> GetAllByChef(int id);
        public Receta FindById(int id);
    }
}
