using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ayni.Models.Partials
{
    internal class PostulacionMetadata
    {
        public int idPostulacion { get; set; }
        public int idPublicacion { get; set; }
        public int idPostulante { get; set; }
        public bool Aceptado { get; set; }
        public System.DateTime fecha { get; set; }

        public virtual Publicacion Publicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
