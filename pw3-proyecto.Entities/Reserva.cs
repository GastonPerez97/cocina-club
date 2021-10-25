using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace pw3_proyecto.Entities
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int IdEvento { get; set; }
        public int IdComensal { get; set; }
        public int IdReceta { get; set; }
        public int CantidadComensales { get; set; }        
        public DateTime FechaCreacion { get; set; }

        public virtual Usuario IdComensalNavigation { get; set; }
        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Receta IdRecetaNavigation { get; set; }
    }
}
