using System;
using System.Collections.Generic;

#nullable disable

namespace pw3_proyecto.Entities
{
    public partial class TipoReceta
    {
        public TipoReceta()
        {
            Receta = new HashSet<Receta>();
        }

        public int IdTipoReceta { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Receta> Receta { get; set; }
    }
}
