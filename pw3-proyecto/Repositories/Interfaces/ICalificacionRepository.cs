using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Repositories.Interfaces
{
    public interface ICalificacionRepository
    {

        public void Save(Calificacione calificacione);

        public bool verifyIfCalificacionExists(int idEvento, int idComensal);
        public List<Calificacione> FindCalificacionByUser(int idComensal);
        public void SaveChanges();

    }
}
