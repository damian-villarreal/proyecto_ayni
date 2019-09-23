using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;

namespace ayni.Repositories
{
    public class PublicacionRepo
    {
        public ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal List<Publicacion> BuscarHome(String s) {
            return Db.Publicacion.Where(x => x.Titulo.Contains(s)).ToList();
        }

        internal List<Publicacion> ListarPedidos() {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1).ToList();
        }

        public void Crear(Publicacion p) {
            Db.Publicacion.Add(p);
            Db.SaveChanges();
        }

        internal List<Publicacion> BuscarPedidosPorIdUsuario(int? id)
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1 && x.idUsuario==id).ToList();
        }

        internal List<Publicacion> BuscarOfrecimientosPorIdUsuario(int? id)
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 2 && x.idUsuario == id).ToList();
        }

        internal Publicacion BuscarFavorPorIdPublicacion(int? id)
        {
            return Db.Publicacion.Include("TipoPublicacion").Include("Categoria").Where(x => x.idPublicacion == id).FirstOrDefault();
        }

    }
}