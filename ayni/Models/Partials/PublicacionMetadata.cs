using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ayni.Models.Partials
{
    internal class PublicacionMetadata
    {
        
        public int idPublicacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Titulo { get; set; }
        public int idUsuario { get; set; }
        public int Valor { get; set; }
        public int idTipoPublicacion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public System.DateTime Fecha_publicacion { get; set; }
        public Nullable<System.DateTime> Fecha_fin { get; set; }
        public int idEstadoPublicacion { get; set; }
        public Nullable<System.DateTime> Fecha_inicio { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int idCategoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual EstadoPublicacion EstadoPublicacion { get; set; }
        public virtual TipoPublicacion TipoPublicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
