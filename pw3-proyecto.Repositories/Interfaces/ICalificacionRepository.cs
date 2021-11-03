using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface ICalificacionRepository
    {

        public void Save(Calificacione calificacione);

        public List<Calificacione> FindCalificacionByIdEventoAndIdComensal(int idEvento, int idComensal);
        public void SaveChanges();

    }
}
