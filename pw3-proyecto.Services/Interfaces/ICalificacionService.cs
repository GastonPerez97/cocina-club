using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface ICalificacionService
    {

        public bool verifyIfCalificacionExists(int idEvento, int idComensal);

        public List<Calificacione> FindCalificacionByUser(int idComensal);
        public void Save(Calificacione calificacione);

    }
}
