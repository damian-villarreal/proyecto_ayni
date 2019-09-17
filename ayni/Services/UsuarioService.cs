using ayni.Models;
using ayni.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Services
{
    public class UsuarioService
    {
        ProyectoAyniEntities ctx = new ProyectoAyniEntities();

        //Alta
        public bool Alta(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();
            return true;
        }
    }
}