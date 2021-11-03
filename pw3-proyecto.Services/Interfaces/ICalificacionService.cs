using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface ICalificacionService
    {

        public List<Calificacione> FindCalificacionByIdEventoAndIdComensal(int idEvento, int idComensal);
        public void Save(Calificacione calificacione);

    }
}
