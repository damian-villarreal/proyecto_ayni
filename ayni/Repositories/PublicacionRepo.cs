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
            return Db.Publicacion.Where(x => x.Titulo.Contains(s)).OrderByDescending(x => x.Fecha_publicacion).ToList();
        }

        internal List<Publicacion> ListarPedidos() {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1).OrderByDescending(x => x.Fecha_publicacion).ToList();
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

        internal Publicacion BuscarPublicacion1xId(int? id)
        {
            return Db.Publicacion.Where(x => x.idPublicacion == id).FirstOrDefault();
        }


        public int Modificar(Publicacion p)
        {
            Publicacion publicacion = this.BuscarFavorPorIdPublicacion(p.idPublicacion);
            publicacion.Titulo = p.Titulo;
            publicacion.Valor = p.Valor;
            publicacion.idTipoPublicacion = p.idTipoPublicacion;
            publicacion.idCategoria = p.idCategoria;
            publicacion.Descripcion = p.Descripcion;
            publicacion.Fecha_inicio = p.Fecha_inicio;
            publicacion.Fecha_fin = p.Fecha_fin;
            publicacion.idEstadoPublicacion = p.idEstadoPublicacion;

            return Db.SaveChanges();
        }

        //Baja
        public int Eliminar1(Publicacion p)
        {
            Publicacion publicacion = this.BuscarFavorPorIdPublicacion(p.idPublicacion);
            Db.Publicacion.Remove(publicacion);
            return Db.SaveChanges();
        }

        public void Guardar()
        {
            Db.SaveChanges();
        }
    }
}