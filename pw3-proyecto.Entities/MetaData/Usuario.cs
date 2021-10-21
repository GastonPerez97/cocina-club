using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace pw3_proyecto.Entities
{
    [ModelMetadataType(typeof(UsuarioModelMetaData))]
    public partial class Usuario { }

    public class UsuarioModelMetaData
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "El campo E-Mail es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato de E-Mail no es válido.")]
        [StringLength(50, ErrorMessage = "El E-Mail no puede tener más de 50 caracteres.")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [RegularExpression(@"^[A-Z]{1}(?=.*\d)[A-Za-z\d]{7,}$", ErrorMessage = "La contraseña debe tener mínimo 8 caracteres, empezar con mayúscula y contener al menos 1 número.")]
        public string Password { get; set; }

        [DisplayName("Confirmar Contraseña")]
        [Required(ErrorMessage = "El campo Confirmar Contraseña es obligatorio.")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El perfil es obligatorio.")]
        [RegularExpression(@"^0|1$")]
        public int Perfil { get; set; }
    }
}
