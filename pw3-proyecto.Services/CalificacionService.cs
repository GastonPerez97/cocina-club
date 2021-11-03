using pw3_proyecto.Entities;
using pw3_proyecto.Repositories.Interfaces;
using pw3_proyecto.Services.Interfaces;
using System.Collections.Generic;

namespace pw3_proyecto.Services
{
    public class CalificacionService : ICalificacionService
    {

        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionService(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        public List<Calificacione> FindCalificacionByIdEventoAndIdComensal(int idEvento, int idComensal)
        {
            return _calificacionRepository.FindCalificacionByIdEventoAndIdComensal(idEvento, idComensal);
        }

        public void Save(Calificacione calificacione)
        {
            _calificacionRepository.Save(calificacione);
            _calificacionRepository.SaveChanges();
        }

    }
}
