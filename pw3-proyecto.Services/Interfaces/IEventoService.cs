using pw3_proyecto.Entities;
using System.Collections.Generic;

namespace pw3_proyecto.Services.Interfaces
{
    public interface IEventoService
    {
        public void Save(Evento evento);
        public void LinkRecipesToEvent(Evento evento, List<int> recetasId);
    }
}