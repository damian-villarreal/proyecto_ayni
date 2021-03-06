﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ayni.Models;
using System.Data.Entity;
using ayni.Services;

namespace ayni.Repositories
{
    public class PublicacionRepo
    {
        public ProyectoAyniEntities Db = new ProyectoAyniEntities();

        internal List<Publicacion> BuscarHome(String s)
        {
            return Db.Publicacion.Where(x => x.Titulo.Contains(s) && x.idEstadoPublicacion == 1).OrderByDescending(x => x.Fecha_publicacion).ToList();
        }

        internal List<Publicacion> ListarTodos()
        {
            return Db.Publicacion.OrderByDescending(x => x.Fecha_publicacion).ToList();
        }


        internal List<Publicacion> ListarPedidos()
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1 && x.idEstadoPublicacion == 1)
                .OrderByDescending(x => x.Fecha_publicacion)
                .ToList();
        }


        internal List<Publicacion> ListarPedidosHome()
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1 && x.idEstadoPublicacion == 1)
                .OrderByDescending(x => x.Fecha_publicacion)
                .Take(4)
                .ToList();
        }




        internal List<Publicacion> ListarOfrecidosHome()
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 2)
                .OrderByDescending(x => x.Fecha_publicacion)
                .Take(4)
                .ToList();
        }


        internal List<Publicacion> ListarOfrecidos()
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 2)
                .OrderByDescending(x => x.Fecha_publicacion)
                .ToList();
        }



        public void Crear(Publicacion p)
        {
            Db.Publicacion.Add(p);
            Db.SaveChanges();
        }

        internal List<Publicacion> BuscarPedidosPorIdUsuario(int? id)
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 1 && x.idUsuario == id).ToList();
        }

        internal List<Publicacion> BuscarPublicacionesPostuladasPorUsuario(int? id)
        {

            List<Postulacion> postulaciones = Db.Postulacion.Where(p => p.idPostulante == id).ToList();
            List<Publicacion> publicaciones = new List<Publicacion>();

            foreach (Postulacion pos in postulaciones)
            {
                Publicacion pub = Db.Publicacion
                    .Where(x => x.idPublicacion == pos.idPublicacion)
                .FirstOrDefault();
                publicaciones.Add(pub);
            }
            return publicaciones;
        }

        public Publicacion BuscarPorId(int? idPublicacion) {
            
            return Db.Publicacion.Where(x=>x.idPublicacion == idPublicacion).FirstOrDefault();
        }


        public List<Publicacion> BuscarPublicacionPorContenido(string s)
        {
            var q = from p in Db.Publicacion where p.Titulo.Contains(s) || p.Descripcion.Contains(s) select p;
            return q.ToList();
        }


        internal List<Publicacion> BuscarOfrecimientosPorIdUsuario(int? id)
        {
            return Db.Publicacion.Where(x => x.idTipoPublicacion == 2 && x.idUsuario == id).ToList();
        }

        internal Publicacion BuscarFavorPorIdPublicacion(int? id)
        {
            return Db.Publicacion
                .Include( x => x.TipoPublicacion)
                .Include(x => x.Postulacion)
                .Include(x => x.Categoria)
                .Include(x => x.EstadoPublicacion)
                .Where(x => x.idPublicacion == id)
                .FirstOrDefault();
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
            publicacion.Imagen = p.Imagen;
            publicacion.EstadoPublicacion = Db.EstadoPublicacion
                .Where(x=>x.idEstadoPublicacion==p.idEstadoPublicacion)
                .FirstOrDefault();
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

        public void FinalizarPublicacion(int? idPublicacion) {
            Publicacion p = Db.Publicacion.Where(x => x.idPublicacion == idPublicacion).FirstOrDefault();
            p.idEstadoPublicacion = 3;
            Db.SaveChanges();
        }

        public void CancelarPublicacion(int? idPublicacion) {
            Publicacion p = Db.Publicacion.Where(x => x.idPublicacion == idPublicacion).FirstOrDefault();
            p.idEstadoPublicacion = 3;
            Db.SaveChanges();
        }

        public int? ObtenerPrecioDePublicacionesActivas(int? idUsuario) {

            int? suma = 0;
           
            List<Publicacion>publicacionesActivas =
                Db.Publicacion.Where(x =>
                (x.idUsuario == idUsuario)
                && (
                (x.idEstadoPublicacion == 1)
                || (x.idEstadoPublicacion == 2))).ToList();

            if (publicacionesActivas != null) {
                foreach (Publicacion p in publicacionesActivas) {
                    suma = suma + p.Valor;
                }                
            }

            return suma;
        }
    }
}