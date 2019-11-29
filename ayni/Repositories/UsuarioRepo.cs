using ayni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ayni.Repositories
{
    public class UsuarioRepo
    {
        public ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal Usuario FindUserByAddress(string Address) {
            return Db.Usuario.Where(x => x.Address == Address).FirstOrDefault();
        }

        internal Usuario FindUserById(int id)
        {
            return Db.Usuario.Where(x => x.idUsuario == id).FirstOrDefault();
        }

        public void ActualizarFavoresRealizados(Usuario usuario) {
            Usuario u = Db.Usuario.Where(x => x.idUsuario == usuario.idUsuario).FirstOrDefault();
            u.CantidadFavoresRealizados = usuario.CantidadFavoresRealizados;
            Db.SaveChanges();
        }

        public void ActualizarFavoresRecibidos(Usuario usuario)
        {
            Usuario u = Db.Usuario.Where(x => x.idUsuario == usuario.idUsuario).FirstOrDefault();
            u.CantidadFavoresRecibidos = usuario.CantidadFavoresRecibidos;
            Db.SaveChanges();
        }

        public void ActualizarCalificacionPedidos(Usuario usuario) {
            Usuario u = Db.Usuario.Where(x => x.idUsuario == usuario.idUsuario).FirstOrDefault();
            u.CalificaciónPedidos = usuario.CalificaciónPedidos;
            Db.SaveChanges();
        }

        public void ActualizarCalificacionOfrecidos(Usuario usuario)
        {
            Usuario u = Db.Usuario.Where(x => x.idUsuario == usuario.idUsuario).FirstOrDefault();
            u.CalificaciónOfrecidos = usuario.CalificaciónOfrecidos;
            Db.SaveChanges();
         }
        }
}