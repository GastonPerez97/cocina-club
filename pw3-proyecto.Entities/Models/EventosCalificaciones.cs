using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Entities.Models
{
    public class EventosCalificaciones
    {
        public List<Evento> Eventos { get; set; }

        public Calificacione Calificacione { get; set; }

        public int IdUsuarioSession { get; set; }

        public EventosCalificaciones(List<Evento> eventos, int idUsuarioSession)
        {
            this.Eventos = eventos;
            this.IdUsuarioSession = idUsuarioSession;

        }

    }
}
