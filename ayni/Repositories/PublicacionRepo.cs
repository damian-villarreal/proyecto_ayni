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

    }
}