using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pw3_proyecto.Entities.Model
{
    public class ConfirmarReserva
    {
        public int IdEvento { get; set; }
        public int IdComensal { get; set; }
        [DisplayName("Cuantos vienen a comer?")]
        [Required]
        public int CantidadComensales { get; set; }
        
        [DisplayName("Elegi tu menu")]
        public List<Receta> recetas { get; set; }
        
        [Required(ErrorMessage = "Tenes que seleccionar una receta")]
        public int IdRecetaElegida { get; set; }
    }
}
