using System.Collections.Generic;
using System.Linq;

namespace pw3_proyecto.Entities.Models
{
    public class EventosCalificaciones
    {
        public List<Evento> Eventos { get; set; }

        public List<Evento> EventosConCalificacionDelUsuario { get; set; }

        public List<Calificacione> calificaciones { get; set; }

        public Calificacione Calificacione { get; set; }

        public int IdUsuarioSession { get; set; }

        public EventosCalificaciones(List<Evento> eventos, int idUsuarioSession, List<Evento> eventosCalificacionDelUsuario, List<Calificacione> calif)
        {
            this.Eventos = eventos;
            this.IdUsuarioSession = idUsuarioSession;
            this.EventosConCalificacionDelUsuario = eventosCalificacionDelUsuario;
            this.calificaciones = calif;
        }

        public Calificacione buscarCalificacion(int idEvento)
        {
            return calificaciones.FirstOrDefault(o => o.IdEvento == idEvento);
        }
    }
}
