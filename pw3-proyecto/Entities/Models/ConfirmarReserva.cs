using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pw3_proyecto.Entities.Model
{
    public class ConfirmarReserva
    {
        public int IdEvento { get; set; }
        public int IdComensal { get; set; }

        [DisplayName("¿Cuántos vienen a comer?")]
        [Required(ErrorMessage = "Elige la cantidad de comensales.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad ingresada no es correcta.")]
        public int CantidadComensales { get; set; }
        
        [DisplayName("Elige la receta a probar:")]
        public List<Receta> recetas { get; set; }
        
        [Required(ErrorMessage = "Elige una receta para probar en el evento.")]
        [Range(1, int.MaxValue, ErrorMessage = "Elige una receta para probar en el evento.")]
        public int IdRecetaElegida { get; set; }
    }
}
