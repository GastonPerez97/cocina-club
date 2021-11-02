using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pw3_proyecto.Entities.Models
{
    public class EventosCalificaciones
    {
        public List<Evento> Eventos { get; set; }

        public Calificacione Calificacione { get; set; }

        public EventosCalificaciones(List<Evento> eventos, Calificacione calificacione)
        {
            this.Eventos = eventos;
            this.Calificacione = calificacione;

        }

    }
}
