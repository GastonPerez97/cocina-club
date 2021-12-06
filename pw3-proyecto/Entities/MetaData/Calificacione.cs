using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using pw3_proyecto.Common.CustomDataAnnotations;

namespace pw3_proyecto.Entities
{
    [ModelMetadataType(typeof(CalificacioneModelMetaData))]
    public partial class Calificacione { }
    public class CalificacioneModelMetaData
    {

        [Required(ErrorMessage = "El campo calificación es obligatorio")]

        [Range(1, 5, ErrorMessage = "La puntuación debe ser entre 1 y 5")]
        public int Calificacion { get; set; }

        [Required(ErrorMessage = "Agregue un comentario")]
        public string Comentarios { get; set; }

    }
}
