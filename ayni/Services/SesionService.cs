using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Services
{
    public class SesionService
    {
        ProyectoAyniEntities ctx = new ProyectoAyniEntities();

        public Usuario Iniciar(Usuario usuario)
        {
            var query = from u in ctx.Usuario where u.NombreUsuario == usuario.NombreUsuario && u.Password == usuario.Password select u;
            var usuarioResult = query.FirstOrDefault();
            return usuarioResult;
        }
    }
}