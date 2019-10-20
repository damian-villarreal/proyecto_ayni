using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ayni.Models
{

    internal class PostulacionMetadata
    {
   

        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreUsuario { get; set; }
        public int CantidadFavoresRealizados { get; set; }
        public int CantidadFavoresRecibidos { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

    }
}
