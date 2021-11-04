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

        public bool verifyIfCalificacionExists(int idEvento, int idComensal)
        {
            return _calificacionRepository.verifyIfCalificacionExists(idEvento, idComensal);
        }

        public List<Calificacione> FindCalificacionByUser(int idComensal)
        {
            return _calificacionRepository.FindCalificacionByUser(idComensal);
        }

        public void Save(Calificacione calificacione)
        {
            _calificacionRepository.Save(calificacione);
            _calificacionRepository.SaveChanges();
        }

    }
}
