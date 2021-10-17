using pw3_proyecto.Entities;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface IRecetaRepository
    {
        public void Save(Receta recipe);
        public void SaveChanges();
    }
}
