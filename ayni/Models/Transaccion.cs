//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ayni.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaccion
    {
        public int idTransacion { get; set; }
        public int idUsuarioOfrece { get; set; }
        public int idUsuarioRecibe { get; set; }
        public int idPublicacion { get; set; }
        public int idEstadoTransaccion { get; set; }
    
        public virtual EstadoTransaccion EstadoTransaccion { get; set; }
        public virtual Publicacion Publicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}